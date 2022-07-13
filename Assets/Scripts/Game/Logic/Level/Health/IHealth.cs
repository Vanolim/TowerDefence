using System;

public interface IHealth
{
    public event Action OnEmpty;
    public event Action<float> OnChanged;
    public float CurrentHealth { get; }
    public void SetInitialHealth(float value);
    public void ReceiveDamage(float value);
    public void AddHealth(float value);
}