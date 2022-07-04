using System;

public class EnemyHealth
{    
    private float _health;
    private readonly EnemyAnimation _enemyAnimation;

    public event Action<float> OnHealthChanged;
    public event Action OnHealthOver;

    public float Health
    {
        get => _health;
        private set
        {
            _health = value;
            OnHealthChanged?.Invoke(_health);
        }
    }

    public EnemyHealth(float initialHealth, EnemyAnimation enemyAnimation)
    {
        Health = initialHealth;
        _enemyAnimation = enemyAnimation;
    }

    public void RemoveHealth(float value)
    {
        if (Health - value <= 0)
        {
            _enemyAnimation.PlayDead();
            Health = 0;
            OnHealthOver?.Invoke();
        }
        else
        {
            _enemyAnimation.PlayHit();
            Health -= value;
        }
    }

    public void AddHealth(float value) => Health += value;
}