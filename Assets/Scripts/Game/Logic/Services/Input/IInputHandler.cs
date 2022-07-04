using System;

public interface IInputHandler : IService
{
    public event Action<IGoodsView> OnTouchPlaceForSale;
    public event Action<IGoodsView> OnTouchTowerPlace;
    public event Action<IGoodsView> OnTouchRawMine;
}