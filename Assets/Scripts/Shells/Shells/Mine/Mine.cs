using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Shell
{
    [SerializeField] private float _searchSphereRadius;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private MineEffects _mineEffects;
    
    private Vector3 _launchPoint;
    private Vector3 _launchVelocity;
    private float _age;
    private bool _isReachedGround = false;

    protected override void Init()
    {
        _launchPoint = transform.position;
        _launchVelocity = LaunchVelocity;
    }

    public override void Tick(float dt)
    {
        if (_isReachedGround == false)
        {
            _age += dt;
            MoveAlongPath();

            if (CheckingReachedGround())
            {
                TryDamageEnemies();

                _meshRenderer.enabled = false;
                StartCoroutine(PlayRecycle());
            }
        }
    }

    private void MoveAlongPath()
    {
        Vector3 nextPosition = _launchPoint + _launchVelocity * _age;
        nextPosition.y -= 0.5f * 9.81f * _age * _age;
        transform.localPosition = nextPosition;
    }

    private void TryDamageEnemies()
    {
        _isReachedGround = true;
        List<Enemy> hurtEnemies = FindNearbyEnemies(_searchSphereRadius);
        if (hurtEnemies.Count != 0)
        {
            foreach (var enemy in hurtEnemies)
            {
                ToDamage(enemy);
            }
        }
    }
    
    private List<Enemy> FindNearbyEnemies(float searchSphereRadius)
    {
        int maxColliders = 10;
        Collider[] targets = new Collider[maxColliders];
        
        Physics.OverlapSphereNonAlloc(transform.position, searchSphereRadius, targets, EnemyLayerMask);
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

    private IEnumerator PlayRecycle()
    {
        _mineEffects.PlayEffects();
        yield return new WaitForSeconds(1f);
        Recycle();
        Destroyed();
    }
}
