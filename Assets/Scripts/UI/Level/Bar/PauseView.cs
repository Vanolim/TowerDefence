using UnityEngine;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [SerializeField] private Button _menu;
    [SerializeField] private Button _return;
    [SerializeField] private Button _close;
    [SerializeField] private Button _stopMusic;
    [SerializeField] private Button _playMusic;
    [SerializeField] private Button _changeMusic;
    
    public Button Menu => _menu;
    public Button Return => _return;
    public Button Close => _close;
    public Button StopMusic => _stopMusic;
    public Button PlayMusic => _playMusic;
    public Button ChangeMusic => _changeMusic;
    
    public void Activate() => gameObject.SetActive(true);
    public void DeActivate() => gameObject.SetActive(false);

    public void EnablePlayMusicButton()
    {
        _playMusic.gameObject.SetActive(true);
        _stopMusic.gameObject.SetActive(false);
    }
    
    public void EnableStopMusicButton()
    {
        _playMusic.gameObject.SetActive(false);
        _stopMusic.gameObject.SetActive(true);
    }
}