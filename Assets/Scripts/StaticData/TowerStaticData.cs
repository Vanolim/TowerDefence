using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TowerData", menuName = "StaticData/Tower")]
public class TowerStaticData : ScriptableObject
{
    public TowerTypeId TowerTypeId;
    
    [Range(1.5f, 10f)] 
    public float TargetingRange = 2f;
    
    [Range(1f, 5f)] 
    public float RechargeTime;
    
    [Range(20f, 100f)]
    public int Price;

    public Sprite ImageForButton;

    public Tower Prefab;
}