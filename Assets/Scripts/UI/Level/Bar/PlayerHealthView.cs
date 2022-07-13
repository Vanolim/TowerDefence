using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHealthView : MonoBehaviour, IDisposable
{
    [SerializeField] private List<HeartView> _hearts;
    
    private int _initialHealth;
    private IHealth _playerHealth;
    private IAudioPlayer _audioPlayer;

    private const int MAX_COUNT_HEALTH = 3;

    public void Init(IHealth playerHealth, IAudioPlayer audioPlayer)
    {
        _audioPlayer = audioPlayer;
        
        if (playerHealth.CurrentHealth > MAX_COUNT_HEALTH)
        {
            Debug.Log("Начальное здоровье игрока больше допустимого!");
        }
        else
        {
            _playerHealth = playerHealth;
            _initialHealth = Convert.ToInt32(playerHealth.CurrentHealth);
            
            playerHealth.OnChanged += RemoveHeart;
            playerHealth.OnEmpty += Dispose;
            
            ActivateView();
        }
    }
    

    private void ActivateView()
    {
        for (int i = 0; i < _initialHealth; i++)
        {
            _hearts[i].Activate();
        }
    }

    private void RemoveHeart(float value)
    {
        foreach (var item in _hearts.Where(item => item.IsActive))
        {
            item.Deactivate();
            _initialHealth--;
            _audioPlayer.PlaySoundHealth();
            return;
        }
    }

    public void Dispose()
    {
        _playerHealth.OnChanged -= RemoveHeart;
        _playerHealth.OnEmpty -= Dispose;
    }
}