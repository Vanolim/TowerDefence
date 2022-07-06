public class PurchaseRadialViewHandler : IDisposable
{
    private readonly SellView _sellView;
    private readonly Wallet _wallet;
    private readonly IAudioPlayer _audioPlayer;
    private IGoodsView _currentGoodsView;
    private ItemView _currentItemView;

    public SellView SellView => _sellView;
    public IGoodsView CurrentGoodsView => _currentGoodsView;

    public PurchaseRadialViewHandler(SellView sellView, Wallet wallet, IAudioPlayer audioPlayer)
    {
        _sellView = sellView;
        _wallet = wallet;
        _audioPlayer = audioPlayer;

        InitClose();
    }

    private void InitClose()
    {
        _sellView.OnCloseButton += DeactivateView;
    }
    
    public void HandleInputView(IGoodsView inputGoodsView, ItemView itemView)
    {
        if(inputGoodsView.IsActive == false)
            return;

        _currentItemView = itemView;
        if (_currentGoodsView == null)
            _currentGoodsView = inputGoodsView;
        
        if(itemView.IsActive && inputGoodsView == _currentGoodsView)
            return;

        if(CheckAllViewDisabled() || CheckSelectedNewPurchased(inputGoodsView))
        {
            inputGoodsView.OnNotActive += DeactivateView;
            _currentGoodsView = inputGoodsView;
            _sellView.Activate(_currentGoodsView.GetTransformObject().position);
            itemView.Activate();
        }
    }
    
    private bool CheckAllViewDisabled() 
        => _sellView.IsActive == false || _currentItemView.IsActive == false;
    private bool CheckSelectedNewPurchased(IGoodsView inputGoodsView) 
        => _currentItemView.IsActive && inputGoodsView != _currentGoodsView && inputGoodsView.IsFree;

    public bool TryBuy(int price, bool isButtonStateViewPrice)
    {
        if (isButtonStateViewPrice)
        {
            if (_wallet.TryBuy(price))
            {
                MakeSelectionTowerSuccessful();
                return true;
            }
            MakeSelectionTowerError();
            return false;
        }

        return false;
    }
    
    private void MakeSelectionTowerSuccessful()
    {
        PlaySoundClickButton();
        _currentGoodsView.SetIsNotFree();
        DeactivateView();
    }

    private void DeactivateView() => _sellView.Deactivate();

    private void MakeSelectionTowerError()
    {
        PlaySoundError();
        _currentItemView.PlayNegativeAnimationButton();
    }

    private void PlaySoundClickButton() => _audioPlayer.PlayClickButton();
    private void PlaySoundError() => _audioPlayer.PlaySoundError();

    public void Dispose()
    {
        _sellView.Dispose();
        _sellView.OnCloseButton -= DeactivateView;
    }
}