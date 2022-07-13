using System;

public class Health : IHealth
{
    private float _currentHealth;
    
    public event Action OnEmpty;
    public event Action<float> OnChanged;

    public float CurrentHealth => _currentHealth;

    public void SetInitialHealth(float value) => _currentHealth = value;

    public void ReceiveDamage(float value)
    {
        if (_currentHealth - value <= 0)
        {
            _currentHealth = 0;
            OnEmpty?.Invoke();
        }
        else
        {
            _currentHealth -= value;
        }
        OnChanged?.Invoke(_currentHealth);
    }

    public void AddHealth(float value)
    {
        _currentHealth += value;
        OnChanged?.Invoke(_currentHealth);
    }
}