using System.Collections.Generic;
using UnityEngine;

public abstract class ItemView : MonoBehaviour
{
    [SerializeField] private Color _errorColor;
    [SerializeField] private Sprite _cristalImage;
    [SerializeField] protected List<SellButton> AllSellButton;
    
    private SellButton _currentButton;
    private bool _isButtonOnPriceDisplay;
    private bool _isActive;

    public bool IsActive => _isActive;

    public void PlayNegativeAnimationButton()
    {
        if (_currentButton.IsPlayNegativeAnimation == false)
            _currentButton.PlayNegativeAnimation(_errorColor);
    }

    protected void InitButton(SellButton sellButton, Sprite sellObject, int price)
    {
        sellButton.InitSaleObjectImage(sellObject);
        sellButton.InitCristalImage(_cristalImage);
        sellButton.InitPrice(price);
        sellButton.Activate();
    }

    protected void ChangeViewButton(SellButton button)
    {
        if(_currentButton != null)
            _currentButton.ViewSaleObjectOnButton();
        _currentButton = button;

        if (_currentButton.IsPlayNegativeAnimation == false)
        {
            if(_currentButton.IsStatePriceView)
                _currentButton.ViewSaleObjectOnButton();
            else
                _currentButton.ViewPriceOnButton();
        }
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }
}