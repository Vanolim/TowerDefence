using UnityEngine;

public class CrystalMineBuyHandler : IDisposable
{
    private readonly PurchaseRadialViewHandler _purchaseRadialViewHandler;
    private readonly SpawnerCrystalMine _spawnerCrystalMine;
    private readonly TouchHandler _touchHandler;
    private readonly IAudioPlayer _audioPlayer;
    private CrystalMineView _crystalMineView;
    private int _price;

    public CrystalMineBuyHandler(PurchaseRadialViewHandler purchaseRadialViewHandler,
        SpawnerCrystalMine spawnerCrystalMine,
        ILevelData levelData, TouchHandler touchHandler, IAudioPlayer audioPlayer)
    {
        _purchaseRadialViewHandler = purchaseRadialViewHandler;
        _spawnerCrystalMine = spawnerCrystalMine;
        _touchHandler = touchHandler;
        _audioPlayer = audioPlayer;

        Init(levelData);
    }

    private void Init(ILevelData levelData)
    {
        _crystalMineView = _purchaseRadialViewHandler.SellView.GetSellView<CrystalMineView>();
        _price = levelData.CrystalMinePrice;
        _crystalMineView.Init(_price);
        _crystalMineView.OnBuyButton += TryBuy;
        _touchHandler.OnTouchRawMine += ActivateView;
    }
    

    private void TryBuy(bool isButtonStateViewPrice)
    {
        PlaySoundButton();
        if (_purchaseRadialViewHandler.TryBuy(_price, isButtonStateViewPrice))
        {
            var lastCrystalMinePosition = _purchaseRadialViewHandler.CurrentGoodsView.GetTransformObject();
            _spawnerCrystalMine.SpawnCrystalWorking(lastCrystalMinePosition);
            Object.Destroy(lastCrystalMinePosition.gameObject);
        }
    }

    private void ActivateView(IGoodsView crystalMine)
    {
        PlaySoundTouchOnCrystalMine();
        _purchaseRadialViewHandler.HandleInputView(crystalMine, _crystalMineView);
    }

    public void Dispose()
    {
        _crystalMineView.OnBuyButton -= TryBuy;
        _touchHandler.OnTouchRawMine -= ActivateView;
    }
    
    private void PlaySoundButton() => _audioPlayer.PlayClickButton();
    private void PlaySoundTouchOnCrystalMine() => _audioPlayer.PlaySoundTouchCrystalMine();
}