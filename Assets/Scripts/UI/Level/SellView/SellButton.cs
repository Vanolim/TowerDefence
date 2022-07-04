using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SellButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _price;

    private Sprite _saleObjectImage;
    private Sprite _cristalImage;
    private Color _initialColor;
    private bool _isStatePriceView;
    private bool _isPlayNegativeAnimation;

    public Button Button => _button;
    public bool IsPlayNegativeAnimation => _isPlayNegativeAnimation;
    public bool IsStatePriceView => _isStatePriceView;

    private void OnEnable()
    {
        _isPlayNegativeAnimation = false;
        _initialColor = _image.color;
        ResetColor();
        ViewSaleObjectOnButton();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void InitSaleObjectImage(Sprite saleObject) => _saleObjectImage = saleObject;

    public void InitCristalImage(Sprite cristalImage) => _cristalImage = cristalImage;

    public void InitPrice(int price) => _price.text = price.ToString();

    public void ViewSaleObjectOnButton()
    {
        _isStatePriceView = false;
        ResetColor();
        _price.gameObject.SetActive(false);
        SetSellObjectImage();
    }

    private void SetSellObjectImage() => _image.sprite = _saleObjectImage;

    public void ViewPriceOnButton()
    {
        _isStatePriceView = true;
        ResetColor();
        _price.gameObject.SetActive(true);
        SetCristalImage();
    }
    private void SetCristalImage() => _image.sprite = _cristalImage;

    public void PlayNegativeAnimation(Color errorColor)
    {
        _isPlayNegativeAnimation = true;
        _image.DOColor(errorColor, 0.5f).From().SetLoops(1, LoopType.Restart).OnComplete(() => _isPlayNegativeAnimation = false);
    }

    private void ResetColor() => _image.color = _initialColor;
}