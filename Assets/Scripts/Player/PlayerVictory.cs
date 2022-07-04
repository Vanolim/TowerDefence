using System;

public class PlayerVictory
{
    private readonly IPauseHandler _pauseHandler;
    private readonly IAudioPlayer _audioPlayer;

    public event Action OnVictory;

    public PlayerVictory(IPauseHandler pauseHandler, IAudioPlayer audioPlayer)
    {
        _pauseHandler = pauseHandler;
        _audioPlayer = audioPlayer;
    }

    public void Win()
    {
        _audioPlayer.StopMusic();
        _audioPlayer.PlayVictorySound();
        _pauseHandler.SetPause(true);
        OnVictory?.Invoke();
    }
}