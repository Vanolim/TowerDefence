using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StandaloneInputService : IInputService
{
    private PlayerInput _playerInput;

    public Vector2 MoveDirection => _playerInput.PlayerStandalone.Move.ReadValue<Vector2>();
    
    public event Action<Vector2> OnTouch;

    public void Init()
    {
        _playerInput = new PlayerInput();
        EnableInput();
        
        PlayerInput.PlayerStandaloneActions _mapInput = _playerInput.PlayerStandalone;
        _mapInput.LeftMouseClick.performed += ctx => Touch();
    }

    private void Touch() => OnTouch?.Invoke(Mouse.current.position.ReadValue());

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