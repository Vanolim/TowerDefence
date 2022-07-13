using UnityEngine;

public class TowerPlace : GoodsView
{
    [SerializeField] private LayerMask _layerAfterSetTower;
    public void SetTower() => gameObject.layer = _layerAfterSetTower;
}
