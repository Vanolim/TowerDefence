using System;
using UnityEngine;

public class MobileInput : IInputService
{
    private PlayerInput _playerInput;
    
    public Vector2 MoveDirection => _playerInput.PlayerMobile.Move.ReadValue<Vector2>();
    public event Action<Vector2> OnTouch;

    public void Init()
    {
        _playerInput = new PlayerInput();
        EnableInput();

        PlayerInput.PlayerMobileActions _mapInput = _playerInput.PlayerMobile;
        _mapInput.TouchClick.performed += ctx => Touch(_mapInput.TouchPostition.ReadValue<Vector2>());
    }
    
    private void Touch(Vector2 position)
    {
        OnTouch?.Invoke(position);
    }

    public void EnableInput() => _playerInput.Enable();

    public void DisableInput() => _playerInput.Disable();

    public void SetPause(bool isPaused)
    {
        if(isPaused)
            DisableInput();
        else
            EnableInput();
    }
}