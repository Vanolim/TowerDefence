using UnityEngine;

public class CrystalRawMine : GoodsView, ITouchable
{
    [SerializeField] private TouchableObjects _touchableObjects;
    public TouchableObjects TouchableObjects => _touchableObjects;
    public IGoodsView GetGoodsView() => this;
}
