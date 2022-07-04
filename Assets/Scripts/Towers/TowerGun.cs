using System;
using UnityEngine;

public abstract class TowerGun : MonoBehaviour
{
    [SerializeField] private Transform _launchPoint;

    public ShellTypeId shellTypeId;
    
    private SpawnerShell _spawnerShell;
    private float _barrelStandardAngleX;
    private float _minAngleX;
    private float _maxAngleX;
    private float _launchSpeed;
    private float _targetingRange;

    private const float MaxAngleRotationUp = 20f;
    private const float MaxAngleRotationDown = 50f;

    public void ShootParabolicTrajectory(Vector3 targetPosition)
    {
        _spawnerShell.Spawn(_launchPoint.position, GetParabolicTrajectory(targetPosition), shellTypeId);
    }
    
    public void Shoot(TargetPoint target)
    {
        _spawnerShell.Spawn(_launchPoint.position, target, shellTypeId);
    }

    public void Init(SpawnerShell spawnerShell, float targetingRange)
    {
        _targetingRange = targetingRange;
        _spawnerShell = spawnerShell;
        CalculateInitialVariables();
    }
    

    private void CalculateInitialVariables()
    {
        _barrelStandardAngleX = transform.rotation.x;
        _maxAngleX = _barrelStandardAngleX + MaxAngleRotationUp;
        _minAngleX = _barrelStandardAngleX - MaxAngleRotationDown;
        
        if(shellTypeId == ShellTypeId.Mine)
            CalculateStartParabolicTrajectory();
    }

    private void CalculateStartParabolicTrajectory()
    {
        float x = _targetingRange;
        float y = transform.position.y;
        _launchSpeed = Convert.ToSingle(Math.Sqrt(9.81f * (y + Math.Sqrt(x * x + y * y))));
    }

    public void TurnToTarget(Vector3 targetPosition, float distanceToTarget)
    {
        float heightToTarget = transform.position.y - targetPosition.y;
        float angleToTarget = Mathf.Atan(heightToTarget / distanceToTarget) * Mathf.Rad2Deg;
        
        transform.localEulerAngles = 
            new Vector3(Mathf.Clamp(_barrelStandardAngleX + angleToTarget, _minAngleX, _maxAngleX), 0, 0);
    }

    private Vector3 GetParabolicTrajectory(Vector3 targetPosition)
    {
        Vector3 launchPoint = _launchPoint.position;

        Vector3 targetPoint = targetPosition;
        targetPoint.y = 0;

        Vector2 dir;
        dir.x = targetPoint.x - launchPoint.x;
        dir.y = targetPoint.z - launchPoint.z;

        float x = dir.magnitude;
        float y = -launchPoint.y;
        dir /= x;

        float g = 9.81f;
        float s = _launchSpeed;
        float s2 = s * s;

        float r = s2 * s2 - g * (g * x * x + 2f * y * s2);
        float tanTheta = (s2 + Mathf.Sqrt(r)) / (g * x);
        float cosTheta = Mathf.Cos(Mathf.Atan(tanTheta));
        float sinTheta = cosTheta * tanTheta;
        
        return new Vector3(s * cosTheta *  dir.x, s * sinTheta, s * cosTheta * dir.y);
    }
}
