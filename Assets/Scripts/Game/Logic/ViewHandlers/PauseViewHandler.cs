using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseViewHandler : IDisposable
{
    private readonly PauseView _pauseView;
    private readonly IPauseHandler _pauseHandler;
    private readonly IAudioPlayer _audioPlayer;
    private readonly Button _pause;

    public event Action OnReturn;
    public event Action OnMenu;
    public PauseViewHandler(PauseView pauseView, Button pause, IPauseHandler pauseHandler, IAudioPlayer audioPlayer)
    {
        _pauseView = pauseView;
        _pause = pause;
        _pauseHandler = pauseHandler;
        _audioPlayer = audioPlayer;
        SubscribeToButtons();
    }

    private void SubscribeToButtons()
    {
        _pauseView.Return.onClick.AddListener(ReturnLevel);
        _pauseView.Menu.onClick.AddListener(OpenMenu);
        _pauseView.Close.onClick.AddListener(Close);
        _pauseView.ChangeMusic.onClick.AddListener(ChangeMusic);
        _pauseView.StopMusic.onClick.AddListener(StopMusic);
        _pauseView.PlayMusic.onClick.AddListener(PlayMusic);
        _pause.onClick.AddListener(OpenView);
    }

    private void OpenView()
    {
        PlaySound();
        _pauseHandler.SetPause(true);
        _pauseView.Activate();
    }

    private void ReturnLevel()
    {
        PlaySound();
        _pauseView.DeActivate();
        OnReturn?.Invoke();
    }

    private void OpenMenu()
    {
        PlaySound();
        _pauseView.DeActivate();
        OnMenu?.Invoke();
    }

    private void Close()
    {
        PlaySound();
        _pauseView.DeActivate();
        _pauseHandler.SetPause(false);
    }

    public void Dispose()
    {
        UnsubscribeToButtons();
    }

    private void UnsubscribeToButtons()
    {
        _pauseView.Return.onClick.RemoveListener(ReturnLevel);
        _pauseView.Menu.onClick.RemoveListener(OpenMenu);
        _pauseView.Close.onClick.RemoveListener(Close);
        _pauseView.ChangeMusic.onClick.RemoveListener(ChangeMusic);
        _pauseView.StopMusic.onClick.RemoveListener(StopMusic);
        _pauseView.PlayMusic.onClick.RemoveListener(PlayMusic);
        _pause.onClick.RemoveListener(OpenView);
    }

    private void PlaySound() => _audioPlayer.PlayClickButton();
    private void ChangeMusic() => _audioPlayer.ChangeMusic();

    private void StopMusic()
    {
        PlaySound();
        _pauseView.EnablePlayMusicButton();
        _audioPlayer.StopMusic();
    }
    private void PlayMusic()
    {
        PlaySound();
        _pauseView.EnableStopMusicButton();
        _audioPlayer.PlayMusic();
    }
}