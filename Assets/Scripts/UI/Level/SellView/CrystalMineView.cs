using System;
using UnityEngine;

public class CrystalMineView : ItemView
{
    [SerializeField] private Sprite _crystalMineImage;
    
    public event Action<bool> OnBuyButton;
    
    public void Init(int price)
    {
        InitSellTowerPlaceButton(price);
    }
    
    private void InitSellTowerPlaceButton(int price)
    {
        SellButton[] usedSellButton = new SellButton[AllSellButton.Count];

        for (int i = 0; i < usedSellButton.Length; i++)
        {
            usedSellButton[i] = AllSellButton[i];
            InitTowerPlaceButton(usedSellButton[i], price);
        }
    }
    
    private void InitTowerPlaceButton(SellButton sellButton, int price)
    {
        InitButton(sellButton, _crystalMineImage, price);
        
        sellButton.Button.onClick.AddListener(delegate
        { OnBuyButton?.Invoke(sellButton.IsStatePriceView); 
            ChangeViewButton(sellButton); });
    }
}