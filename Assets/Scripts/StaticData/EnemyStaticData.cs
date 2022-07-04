using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
public class EnemyStaticData : ScriptableObject
{
    public EnemyTypeId EnemyTypeId;
    
    [Range(1f, 500f)]
    public float Health;
    
    [Range(1f, 10f)]
    public float Speed;
    
    [Range(1f, 50f)]
    public int ValueCrystals;
    
    [Range(1, 100)]
    public int ChanceGiveCrystals;
    
    public Sprite Image;
    public Enemy Prefab;
}
