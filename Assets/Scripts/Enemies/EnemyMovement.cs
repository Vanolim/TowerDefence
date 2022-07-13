using System;
using UnityEngine;

public class EnemyMovement
{
    private readonly EnemyPath _enemyPath;
    private readonly Transform _enemyTransform;
    private Vector3 _currentPosition;
    private Vector3 _targetPosition;
    private readonly float _enemySpeed;

    private const float DISTANCE_ERROR = 0.05f;
    private const float MOVEMENT_SPEED_MULTIPLIER = 0.1f;
    private const float TURN_SPEED_MULTIPLIER = 60f;

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
    public void Tick(float dt)
    {
        if (Vector3.Distance(_enemyTransform.position, _targetPosition) <= DISTANCE_ERROR)
        {
            if (_enemyPath.CheckCurrentWaypointTheEnd())
            {
                OnReachedEndPoint?.Invoke();
                return;
            }
            _currentPosition = _targetPosition;
            _targetPosition = _enemyPath.GetNextWaypoint();
        }
        MoveToNextWaypoint(dt);
    }

    private void MoveToNextWaypoint(float dt)
    {
        Vector3 transformFrom = _currentPosition;
        Vector3 transformTo = _targetPosition;

        _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, transformTo, 
            dt * _enemySpeed * MOVEMENT_SPEED_MULTIPLIER);
        
        
        RotateToNextWaypoint(transformTo, transformFrom, dt);
    }

    private void RotateToNextWaypoint(Vector3 transformTo, Vector3 transformFrom, float dt)
    {
        Vector3 targetDirection = transformTo - transformFrom;

        _enemyTransform.rotation = Quaternion.RotateTowards(_enemyTransform.rotation,
            Quaternion.LookRotation(targetDirection), dt * TURN_SPEED_MULTIPLIER);
    }
}
