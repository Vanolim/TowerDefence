using System;
using UnityEngine;
using Random = UnityEngine.Random;

[SelectionBase]
[RequireComponent(typeof(TargetPoint))]
[RequireComponent(typeof(EnemyAnimation))]
public abstract class Enemy : MonoBehaviour, IProduce
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private EnemyView _enemyView;
    
    private EnemyAnimation _enemyAnimation;
    private EnemyStaticData _enemyStaticData;
    private EnemyMovement _enemyMovement;
    private EnemyHealth _enemyHealth;
    private bool _isDeactivate;
    public EnemyHealth EnemyHealth => _enemyHealth;
    
    public event Action<int> OnGiveCrystals;
    public event Action<IProduce> OnDestroyedProduce;
    public event Action<Enemy> OnDestroyed;
    public event Action OnFinish;


    public void Init(EnemyPath path)
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        
        _enemyMovement = new EnemyMovement(transform, path, _enemyStaticData.Speed);
        _enemyMovement.OnReachedEndPoint += Finish;

        _enemyHealth = new EnemyHealth(_enemyStaticData.Health, _enemyAnimation);
        _enemyHealth.OnHealthOver += Dead;

        _enemyView.EnemyHealthView.Init(_enemyHealth, _enemyStaticData.Health);
    }

    public void SetStaticData(EnemyStaticData staticData)
    {
        _enemyStaticData = staticData;
    }

    public void Tick()
    {
        if(_isDeactivate == false)
            _enemyMovement.Tick();
    }

    private void Dead()
    {
        _audio.Play();
        _isDeactivate = true;
        ChangeLayerMask();
        OnDestroyed?.Invoke(this);
        _enemyView.EnemyHealthView.Deactivate();
    }

    private void ChangeLayerMask()
    {
        gameObject.layer = 0;
    }

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
        {
            int countCrystal = _enemyStaticData.ValueCrystals;
            OnGiveCrystals?.Invoke(countCrystal);
            _enemyView.EnemyProduceView.Activate(countCrystal);
        }
        OnDestroyedProduce?.Invoke(this);
    }

    public void Destroyed()
    {
        Destroy(gameObject);
    }
}
