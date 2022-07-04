using System;
using UnityEngine;

public interface IGoodsView
{
    public event Action OnNotActive;
    public bool IsFree { get; }
    public bool IsActive { get; }
    public Transform GetTransformObject();
    public Transform GetTransformForSpawn();
    public void SetIsNotFree();
    public void Activate();
    public void Deactivate();
}