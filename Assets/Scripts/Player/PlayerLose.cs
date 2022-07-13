using System;

public class PlayerLose : IDisposable
{
    private readonly IHealth _playerHealth;
    private readonly IPauseHandler _pauseHandler;
    private readonly IAudioPlayer _audioPlayer;
    public event Action OnLose;
    public PlayerLose(IHealth playerHealth, IPauseHandler pauseHandler, IAudioPlayer audioPlayer)
    {
        _playerHealth = playerHealth;
        _pauseHandler = pauseHandler;
        _audioPlayer = audioPlayer;
        _playerHealth.OnEmpty += Lose;
    }

    private void Lose()
    {
        _audioPlayer.StopMusic();
        _audioPlayer.PlayLoseSound();
        _pauseHandler.SetPause(true);
        OnLose?.Invoke();
    }

    public void Dispose()
    {
        _playerHealth.OnEmpty -= Lose;
    }
}