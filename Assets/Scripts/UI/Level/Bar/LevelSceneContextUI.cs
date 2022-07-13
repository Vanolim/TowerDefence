using UnityEngine;
using UnityEngine.UI;

public class LevelSceneContextUI : MonoBehaviour, IDisposable
{
    [SerializeField] private BalanceView _balanceView;
    [SerializeField] private SellView _sellView;
    [SerializeField] private PlayerHealthView _playerHealthView;
    [SerializeField] private EndView _endView;
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private Button _pause;
    [SerializeField] private Image _joystick;
    
    public BalanceView BalanceView => _balanceView;
    public SellView SellView => _sellView;
    public PlayerHealthView PlayerHealthView => _playerHealthView;
    public EndView EndView => _endView;
    public PauseView PauseView => _pauseView;
    public Button Pause => _pause;

    public void Init(Wallet wallet, IHealth playerHealth, IAudioPlayer audioPlayer)
    {
        _sellView.Init();
        _balanceView.Init(wallet);
        _playerHealthView.Init(playerHealth, audioPlayer);
        
        SetImageJoystick();
    }

    public void Dispose()
    {
        _balanceView.Dispose();
        _sellView.Dispose();
        _playerHealthView.Dispose();
    }

    private void SetImageJoystick()
    {
        if (Application.isMobilePlatform)
            _joystick.gameObject.SetActive(true);
    }
}