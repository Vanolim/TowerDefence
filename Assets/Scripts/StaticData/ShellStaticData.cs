using UnityEngine;

[CreateAssetMenu(fileName = "ShellData", menuName = "StaticData/Shell")]
public class ShellStaticData : ScriptableObject
{
    public ShellTypeId ShellTypeId;

    [Range(0, 100)] 
    public float Damage;
    
    [Range(0, 10)]
    public float Speed;
    
    public Shell Prefab;
}
