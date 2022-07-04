using TMPro;
using UnityEngine;

public class TowerPlaceForSale : GoodsView
{
    [SerializeField] private TMP_Text _price;
    public void SetPrice(int value) => _price.text = value.ToString();
}
