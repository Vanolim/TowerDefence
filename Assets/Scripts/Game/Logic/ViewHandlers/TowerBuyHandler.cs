using System.Collections.Generic;

public class TowerBuyHandler : IDisposable
{
    private readonly PurchaseRadialViewHandler _purchaseRadialViewHandler;
    private readonly SpawnerTower _spawnerTower;
    private readonly IStaticDataService _staticDataService;
    private readonly TouchHandler _touchHandler;
    private readonly IAudioPlayer _audioPlayer;
    private TowerView _towerView;

    public TowerBuyHandler(PurchaseRadialViewHandler purchaseRadialViewHandler, IStaticDataService staticDataService,
        SpawnerTower spawnerTower, ILevelData levelData, TouchHandler touchHandler, IAudioPlayer audioPlayer)
    {
        _purchaseRadialViewHandler = purchaseRadialViewHandler;
        _staticDataService = staticDataService;
        _spawnerTower = spawnerTower;
        _touchHandler = touchHandler;
        _audioPlayer = audioPlayer;

        Init(staticDataService, levelData);
    }

    private void Init(IStaticDataService staticDataService, ILevelData levelData)
    {
        _towerView = _purchaseRadialViewHandler.SellView.GetSellView<TowerView>();
        _towerView.Init(InitTowers(levelData, staticDataService));

        _towerView.OnBuyButton += TryBuy;
        _touchHandler.OnTouchTowerPlace += ActivateView;
    }

    private List<TowerStaticData> InitTowers(ILevelData levelData, IStaticDataService staticDataService)
    {
        List<TowerStaticData> towerStaticData = new List<TowerStaticData>();
        foreach (var item in levelData.TowersType)
        {
            towerStaticData.Add(staticDataService.ForTowers(item));
        }
        return towerStaticData;
    }

    private void ActivateView(IGoodsView tower)
    {
        PlaySoundTouchOnPlace();
        _purchaseRadialViewHandler.HandleInputView(tower, _towerView);
        
    }

    private void TryBuy(TowerTypeId towerTypeId, bool isButtonStateViewPrice)
    {
        PlaySoundButton();
        if(_purchaseRadialViewHandler.TryBuy(_staticDataService.ForTowers(towerTypeId).Price, isButtonStateViewPrice))
            _spawnerTower.Spawn(towerTypeId, _purchaseRadialViewHandler.CurrentGoodsView);
    }

    public void Dispose()
    {
        _towerView.OnBuyButton -= TryBuy;
        _touchHandler.OnTouchTowerPlace -= ActivateView;
    }
    
    private void PlaySoundButton() => _audioPlayer.PlayClickButton();
    private void PlaySoundTouchOnPlace() => _audioPlayer.PlaySoundTouchPlace();
}
