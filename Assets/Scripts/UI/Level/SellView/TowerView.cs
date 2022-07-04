using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerView : ItemView
{
    public event Action<TowerTypeId, bool> OnBuyButton;

    public void Init(List<TowerStaticData> towersLevelStaticData)
    {
        if (towersLevelStaticData.Count > AllSellButton.Count)
        {
            Debug.Log("Error, max count towers = " + AllSellButton.Count); 
            return;
        }

        for (int i = 0; i < towersLevelStaticData.Count; i++)
        {
            InitTowerButton(AllSellButton[i], towersLevelStaticData[i]);
        }
    }
    
    private void InitTowerButton(SellButton SellButton, TowerStaticData towerStaticData)
    {
        InitButton(SellButton, towerStaticData.ImageForButton, towerStaticData.Price);
        
        SellButton.Button.onClick.AddListener(delegate
        { OnBuyButton?.Invoke(towerStaticData.TowerTypeId, SellButton.IsStatePriceView); 
            ChangeViewButton(SellButton); });
    }
}
