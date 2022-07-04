using UnityEngine;
using UnityEngine.Serialization;

public class MainSceneContextUI : MonoBehaviour, IDisposable
{
    [FormerlySerializedAs("levelScenesView")] [FormerlySerializedAs("loadLevelScenesView")] [SerializeField] private LevelView levelView;

    public LevelView LevelView => levelView;

    public void Init()
    {
        
    }

    public void Dispose()
    {
        //
    }
}