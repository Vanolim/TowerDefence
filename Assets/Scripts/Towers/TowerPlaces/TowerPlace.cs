using UnityEngine;

public class TowerPlace : GoodsView, ITouchable
{
    [SerializeField] private TouchableObjects _touchableObjects;

    public TouchableObjects TouchableObjects => _touchableObjects;
    public IGoodsView GetGoodsView() => this;
    public void SetTower() => gameObject.layer = 2;
}
