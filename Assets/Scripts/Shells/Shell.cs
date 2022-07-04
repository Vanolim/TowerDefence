using System.Collections.Generic;
using UnityEngine;

public abstract class Shell : MonoBehaviour
{
    private float _damage;
    private float _speed;

    private SpawnerShell _spawnerShell;
    private TargetPoint _targetPoint;
    private Vector3 _targetPosition;
    private Vector3 _launchPoint;
    private Vector3 _launchVelocity;
    private int _layerMask;

    private const float HitRegistrationError = 0.2f;
    private const float EarthY = 0.12f;
    private const string LayerName = "Enemy";
    protected Vector3 LaunchPoint => _launchPoint;
    protected Vector3 LaunchVelocity => _launchVelocity;

    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer(LayerName);
    }
    
    public void Init(TargetPoint targetPoint, SpawnerShell spawnerShell)
    {
        _targetPoint = targetPoint;
        _targetPosition = targetPoint.Position;
        _spawnerShell = spawnerShell;
        TurnToTarget();
    }

    public void Init(Vector3 launchVelocity, SpawnerShell spawnerShell)
    {
        _launchPoint = transform.position;
        _launchVelocity = launchVelocity;
        _spawnerShell = spawnerShell;
    }

    public void Init(ShellStaticData staticData)
    {
        _damage = staticData.Damage;
        _speed = staticData.Speed;
    }

    private void TurnToTarget()
    {
        transform.LookAt(_targetPosition);
    }

    public abstract bool GameUpdate();

    protected void Recycle()
    {
        _spawnerShell.Reclaim(this);
    }

    protected bool IsEnemyPosition(Vector3 shellPosition)
    {
        if (Vector3.Distance(shellPosition, _targetPosition) <= HitRegistrationError)
            return true;
        return false;
    }

    protected void ToDamage()
    {
        ToDamage(_targetPoint.Enemy);
    }

    protected void ToDamage(Enemy enemy)
    {
        enemy.EnemyHealth.RemoveHealth(_damage);
    }

    protected void ToDamage(List<Enemy> enemies)
    {
        foreach (var enemy in enemies)
        {
            if(enemy != null)
                enemy.EnemyHealth.RemoveHealth(_damage);
        }
    }

    protected void MoveForward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    protected void Rotate(float age)
    {
        Vector3 d = _launchVelocity;
        d.y -= 9.81f * age * _speed;
        transform.localRotation = Quaternion.LookRotation(d);
    }

    protected List<Enemy> FindNearbyEnemies(float searchSphereRadius)
    {
        int maxColliders = 20;
        Collider[] targets = new Collider[maxColliders];
        
        Physics.OverlapSphereNonAlloc(transform.position, searchSphereRadius, targets, _layerMask);
        List<Enemy> enemies = new List<Enemy>();

        if (targets.Length != 0)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] != null)
                {
                    Enemy enemy = targets[i].gameObject.GetComponent<Enemy>();
                    enemies.Add(enemy);
                }
            }
        }

        return enemies;
    }

    protected bool CheckingReachedGround() => transform.position.y <= EarthY;
}
