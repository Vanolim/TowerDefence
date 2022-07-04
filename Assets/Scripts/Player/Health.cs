using System;

public class Health
{
    private int _currentCount;
    private readonly IAudioPlayer _audioPlayer;

    public event Action<int> OnChanged;
    public event Action OnEmpty;

    public int CurrentCount
    {
        get => _currentCount;
        private set
        {
            _currentCount = value;
            OnChanged?.Invoke(_currentCount);
        }
    }

    public Health(int initialHealth, IAudioPlayer audioPlayer)
    {
        _currentCount = initialHealth;
        _audioPlayer = audioPlayer;
    }

    public void RemoveHealth()
    {
        if ((_currentCount--) <= 0)
        {
            CurrentCount = 0;
            OnEmpty?.Invoke();
        }
        else
        {
            PlaySound();
            CurrentCount--;
        }
    }

    public void AddHealth(int value)
    {
        CurrentCount += value;
    }

    private void PlaySound() => _audioPlayer.PlaySoundHealth();
}