using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellView : MonoBehaviour, IDisposable
{
    [SerializeField] private Button _close;
    [SerializeField] private List<ItemView> _sellViews;

    private bool _isActive;
    private Vector3 _target;
    private Camera _camera;

    public event Action OnCloseButton;
    public bool IsActive => _isActive;

    public void Init()
    {
        InitCloseButton();
        _camera = Camera.main;
    }

    private void InitCloseButton() => _close.onClick.AddListener(() => OnCloseButton?.Invoke());

    private void LateUpdate()
    {
        if (_isActive)
            FollowTheTarget();
    }

    private void FollowTheTarget()
    {
        Vector3 offsetViewPosition = Vector3.up;

        Vector3 screenPosition = _camera.WorldToScreenPoint(_target + offsetViewPosition);
        transform.position = screenPosition;
    }

    public T GetSellView<T>() where T : ItemView
    {
        foreach (var sellView in _sellViews)
        {
            if (sellView.TryGetComponent(out T element))
                return element;
        }

        return null;
    }

    public void Activate(Vector3 targetPosition)
    {
        DeactivateAllItem();
        _isActive = true;
        gameObject.SetActive(true);
        _target = targetPosition;
    }

    public void Deactivate()
    {
        DeactivateAllItem();
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void DeactivateAllItem()
    {
        foreach (var sellView in _sellViews)
        {
            if(sellView != null)
                sellView.Deactivate();
        }
    }

    public void Dispose() => _close.onClick.RemoveListener(() => OnCloseButton?.Invoke());
}