using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthView : MonoBehaviour, IDisposable
{
    [SerializeField] private List<HeartView> _hearts;
    private int _initialHealth;
    private Health _health;

    private const int MAX_COUNT_HEALTH = 3;

    public void Init(Health health)
    {
        if (health.CurrentCount > MAX_COUNT_HEALTH)
        {
            Debug.Log("начальное здоровье игрока больше допустимого!");
        }
        else
        {
            _health = health;
            _initialHealth = health.CurrentCount;
            health.OnChanged += UpdateView;
            health.OnEmpty += Dispose;
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

    private void UpdateView(int valueHealth)
    {
        if (valueHealth > _initialHealth)
            AddHeart();
        else
            RemoveHeart();
    }

    private void AddHeart()
    {
        foreach (var item in _hearts)
        {
            if (item.IsActive == false)
            {
                item.Activate();
                _initialHealth++;
                return;
            }
        }
    }

    private void RemoveHeart()
    {
        foreach (var item in _hearts)
        {
            if (item.IsActive)
            {
                item.Deactivate();
                _initialHealth--;
                return;
            }
        }
    }

    public void Dispose()
    {
        _health.OnChanged -= UpdateView;
        _health.OnEmpty -= Dispose;
    }
}