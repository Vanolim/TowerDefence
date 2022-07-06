using UnityEngine;
using UnityEngine.UI;

public class MainSceneContextUI : MonoBehaviour
{
    [SerializeField] private LevelView _levelView;
    [SerializeField] private Button _exitApplication;

    public LevelView LevelView => _levelView;
    public Button ExitApplication => _exitApplication;
}