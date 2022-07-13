using System;
using UnityEngine;
using Random = UnityEngine.Random;

[SelectionBase]
[RequireComponent(typeof(TargetPoint))]
public class Enemy : MonoBehaviour, IProduce
{
    [SerializeField] private EnemySound _enemySound;
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private LayerMask _defaultLayer;
    
    private EnemyStaticData _enemyStaticData;
    private EnemyMovement _enemyMovement;
    private IHealth _health;
    private bool _isDeactivate;

    public event Action<int> OnGiveCrystals;
    public event Action<IProduce> OnDestroyedProduce;
    public event Action<Enemy> OnDestroyed;
    public event Action OnFinish;

    public void Init(EnemyPath path)
    {
        InitMovement(path);
        InitHealth();
        InitView();
    }

    public void SetStaticData(EnemyStaticData staticData)
    {
        _enemyStaticData = staticData;
    }

    private void InitMovement(EnemyPath path)
    {
        _enemyMovement = new EnemyMovement(transform, path, _enemyStaticData.Speed);
        _enemyMovement.OnReachedEndPoint += Finish;
    }

    private void InitHealth()
    {
        _health = new Health();
        _health.SetInitialHealth(_enemyStaticData.Health);
        _health.OnEmpty += Dead;
    }

    private void InitView()
    {
        _enemyView.Init(_health.CurrentHealth);
        _health.OnChanged += _enemyView.Health.UpdateView;
    }

    public void TakeDamage(float value)
    {
        _enemyAnimation.PlayHit();
        _enemySound.PlayHit();
        _health.ReceiveDamage(value);
    }

    public void Tick(float dt)
    {
        if(_isDeactivate == false)
            _enemyMovement.Tick(dt);
    }

    private void Dead()
    {
        _isDeactivate = true;
        _enemyAnimation.PlayDead();
        _enemySound.PlayDead();
        ChangeLayerMask();
        DeactivateHealth();
    }

    private void DeactivateHealth()
    {
        _health.OnEmpty -= Dead;
        _health.OnChanged -= _enemyView.Health.UpdateView;
        _enemyView.Health.Deactivate();
    }

    private void ChangeLayerMask() => gameObject.layer = _defaultLayer;

    private void Finish()
    {
        OnFinish?.Invoke();
        OnDestroyedProduce?.Invoke(this);
        OnDestroyed?.Invoke(this);
        Destroyed();
    }

    public void TryGiveCrystals()
    {
        if (Random.Range(0, 100) <= _enemyStaticData.ChanceGiveCrystals)
            GiveCrystals();
        
        OnDestroyedProduce?.Invoke(this);
    }

    private void GiveCrystals()
    {
        int countCrystal = _enemyStaticData.ValueCrystals;
        OnGiveCrystals?.Invoke(countCrystal);
        _enemyView.EnemyProduceView.Activate(countCrystal);
    }

    public void Destroyed()
    {
        OnDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
