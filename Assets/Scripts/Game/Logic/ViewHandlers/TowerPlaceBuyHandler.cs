public class TowerPlaceBuyHandler : IDisposable
{
    private readonly PurchaseRadialViewHandler _purchaseRadialViewHandler;
    private readonly SpawnerTowerPlace _spawnerTowerPlace;
    private readonly TouchHandler _touchHandler;
    private readonly IAudioPlayer _audioPlayer;

    private TowerPlaceView _towerPlaceView;
    private int _price;

    public TowerPlaceBuyHandler(PurchaseRadialViewHandler purchaseRadialViewHandler, GameBoard gameBoard,
        SpawnerTowerPlace spawnerTowerPlace, TouchHandler touchHandler, ILevelData levelData, IAudioPlayer audioPlayer)
    {
        _purchaseRadialViewHandler = purchaseRadialViewHandler;
        _spawnerTowerPlace = spawnerTowerPlace;
        _touchHandler = touchHandler;
        _audioPlayer = audioPlayer;

        Init(gameBoard, levelData);
    }

    private void Init(GameBoard gameBoard, ILevelData levelData)
    {
        _towerPlaceView = _purchaseRadialViewHandler.SellView.GetSellView<TowerPlaceView>();
        InitPlacesForSale(gameBoard.PlacesForSell, levelData);
        _towerPlaceView.Init(_price);

        _towerPlaceView.OnBuyButton += TryBuy;
        _touchHandler.OnTouchPlaceForSale += ActivateView;
    }

    private void InitPlacesForSale(TowerPlaceForSale[] towerPlaces, ILevelData levelData)
    {
        int price = levelData.TowerPlacePrice;
        foreach (var item in towerPlaces)
        {
            item.SetPrice(price);
        }

        _price = price;
    }

    private void TryBuy(bool isButtonStateViewPrice)
    {
        PlaySoundButton();
        if(_purchaseRadialViewHandler.TryBuy(_price, isButtonStateViewPrice))
            _spawnerTowerPlace.Spawn(_purchaseRadialViewHandler.CurrentGoodsView);
    }

    private void ActivateView(IGoodsView towerPlace)
    {
        PlaySoundTouchOnPlace();
        _purchaseRadialViewHandler.HandleInputView(towerPlace, _towerPlaceView);
    }

    public void Dispose()
    {
        _towerPlaceView.OnBuyButton -= TryBuy;
        _touchHandler.OnTouchPlaceForSale -= ActivateView;
    }

    private void PlaySoundButton() => _audioPlayer.PlayClickButton();
    private void PlaySoundTouchOnPlace() => _audioPlayer.PlaySoundTouchPlace();
}
