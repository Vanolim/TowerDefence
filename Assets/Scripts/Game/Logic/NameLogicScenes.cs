using UnityEngine;

public class NameLogicScenes : MonoBehaviour
{
    [SerializeField] private string _initialScene;
    [SerializeField] private string _mainScene;

    private string _levelScene;

    public string LevelScene => _levelScene;
    
    public string InitialScene => _initialScene;
    public string MainScene => _mainScene;

    public void SetLevelScene(string levelSceneName)
    {
        _levelScene = levelSceneName;
    }
}