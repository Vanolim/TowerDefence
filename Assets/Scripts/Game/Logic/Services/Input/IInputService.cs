using System;
using UnityEngine;

public interface IInputService : IService, IPauseble
{
    public void Init();
    
    public Vector2 MoveDirection { get; }
    public event Action<Vector2> OnTouch;
    
    public void EnableInput();
    public void DisableInput();
}