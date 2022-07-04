using System;
using UnityEngine;

public class EnemyMovement
{
    private readonly EnemyPath _enemyPath;
    private Vector3 _currentPosition;
    private Vector3 _targetPosition;
    private readonly Transform _enemyTransform;
    private readonly float _enemySpeed;

    public event Action OnReachedEndPoint;

    public EnemyMovement(Transform enemyTransform, EnemyPath enemyPath, float enemySpeed)
    {
        _enemyTransform = enemyTransform;
        _enemyPath = enemyPath;
        _enemySpeed = enemySpeed;
        Init();
    }

    private void Init()
    {
        MoveToSpawnWaypoint();
        _targetPosition = _enemyPath.GetNextWaypoint();
    }

    private void MoveToSpawnWaypoint()
    {
        var spawnPosition = _enemyPath.SpawnPosition;
        _enemyTransform.position = spawnPosition.position;
        _enemyTransform.rotation = spawnPosition.rotation;
        _currentPosition = spawnPosition.position;
    }
    public void Tick()
    {
        if (Vector3.Distance(_enemyTransform.position, _targetPosition) <= 0.05f)
        {
            if (_enemyPath.CheckCurrentWaypointTheEnd())
            {
                OnReachedEndPoint?.Invoke();
                return;
            }
            _currentPosition = _targetPosition;
            _targetPosition = _enemyPath.GetNextWaypoint();
        }
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        Vector3 transformFrom = _currentPosition;
        Vector3 transformTo = _targetPosition;

        _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, transformTo, Time.deltaTime * _enemySpeed * 0.1f);
        
        
        RotateToNextWaypoint(transformTo, transformFrom);
    }

    private void RotateToNextWaypoint(Vector3 transformTo, Vector3 transformFrom)
    {
        Vector3 targetDirection = transformTo - transformFrom;

        _enemyTransform.rotation = Quaternion.RotateTowards(_enemyTransform.rotation,
            Quaternion.LookRotation(targetDirection),
            Time.deltaTime * 60f);
    }
}
