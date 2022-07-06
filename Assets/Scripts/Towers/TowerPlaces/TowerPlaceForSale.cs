using TMPro;
using UnityEngine;

public class TowerPlaceForSale : GoodsView, ITouchable
{
    [SerializeField] private TouchableObjects _touchableObjects;
    [SerializeField] private TMP_Text _price;
    public void SetPrice(int value) => _price.text = value.ToString();

    public TouchableObjects TouchableObjects => _touchableObjects;
    public IGoodsView GetGoodsView() => this;
}
