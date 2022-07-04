using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/LevelData")]
public class LevelData : ScriptableObject
{
    public string SceneName;
    public Sprite ImageForButton;
    public string LevelName;
}