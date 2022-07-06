using System;
using UnityEngine;

public class TouchHandler
{
    private IInputHandler _inputHandler;
    
    public event Action<IGoodsView> OnTouchPlaceForSale;
    public event Action<IGoodsView> OnTouchTowerPlace;
    public event Action<IGoodsView> OnTouchRawMine;

    public TouchHandler(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;

        _inputHandler.OnTouch += Test;
    }

    private void Test(ITouchable obj)
    {
        switch (obj.TouchableObjects)
        {
            case TouchableObjects.TowerPlace:
                OnTouchTowerPlace?.Invoke(obj.GetGoodsView());
                break;
            case TouchableObjects.CrystalRawMine:
                OnTouchRawMine?.Invoke(obj.GetGoodsView());
                break;
            case TouchableObjects.TowerPlaceFoSale:
                OnTouchPlaceForSale?.Invoke(obj.GetGoodsView());
                break;
            default:
                Debug.Log("NoneITouchableType");
                break;
        }
    }
}