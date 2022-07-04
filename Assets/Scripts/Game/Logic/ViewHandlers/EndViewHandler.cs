using System;

public class EndViewHandler : IDisposable
{
    private readonly EndView _endView;
    private readonly PlayerLose _playerLose;
    private readonly PlayerVictory _playerVictory;
    private readonly IAudioPlayer _audioPlayer;

    private const string LOSE_TEXT = "LOSE";
    private const string VICTORY_TEXT = "VICTORY";

    public event Action OnReturn;
    public event Action OnMenu;
    public EndViewHandler(EndView endView, PlayerLose playerLose, PlayerVictory playerVictory, IAudioPlayer audioPlayer)
    {
        _endView = endView;
        _playerLose = playerLose;
        _playerVictory = playerVictory;
        _audioPlayer = audioPlayer;

        playerLose.OnLose += OpenLoseView;
        playerVictory.OnVictory += OpenVictoryView;
        SubscribeToButtons();
    }

    private void OpenLoseView()
    {
        _endView.SetText(LOSE_TEXT);
        _endView.SetImageLose();
        _endView.Activate();
    }

    private void OpenVictoryView()
    {
        _endView.SetText(VICTORY_TEXT);
        _endView.SetImageWin();
        _endView.Activate();
    }

    private void SubscribeToButtons()
    {
        _endView.Return.onClick.AddListener(ReturnLevel);
        _endView.Menu.onClick.AddListener(OpenMenu);
    }

    private void ReturnLevel()
    {
        PlaySound();
        _endView.DeActivate();
        OnReturn?.Invoke();
    }

    private void OpenMenu()
    {
        PlaySound();
        _endView.DeActivate();
        OnMenu?.Invoke();
    }

    private void PlaySound() => _audioPlayer.PlayClickButton();

    public void Dispose()
    {
        _playerLose.OnLose -= OpenLoseView;
        _playerVictory.OnVictory -= OpenLoseView;
        UnsubscribeToButtons();
    }

    private void UnsubscribeToButtons()
    {
        _endView.Return.onClick.RemoveListener(ReturnLevel);
        _endView.Menu.onClick.RemoveListener(OpenMenu);
    }
}