using UnityEngine;

public abstract class TowerGun : MonoBehaviour
{
    [SerializeField] protected Transform LaunchPoint;

    public ShellTypeId shellTypeId;
    
    protected SpawnerShell SpawnerShell;
    protected float TargetingRange;

    private float _barrelStandardAngleX;
    private float _minAngleX;
    private float _maxAngleX;

    private const float MaxAngleRotationUp = 20f;
    private const float MaxAngleRotationDown = 50f;

    public void Init(SpawnerShell spawnerShell, float targetingRange)
    {
        TargetingRange = targetingRange;
        SpawnerShell = spawnerShell;
        CalculateInitialVariables();
        Init();
    }

    protected abstract void Init();
    public abstract void Shoot(TargetPoint targetPoint);
    
    private void CalculateInitialVariables()
    {
        _barrelStandardAngleX = transform.rotation.x;
        _maxAngleX = _barrelStandardAngleX + MaxAngleRotationUp;
        _minAngleX = _barrelStandardAngleX - MaxAngleRotationDown;
    }
    
    public void TurnToTarget(Vector3 targetPosition, float distanceToTarget)
    {
        float heightToTarget = transform.position.y - targetPosition.y;
        float angleToTarget = Mathf.Atan(heightToTarget / distanceToTarget) * Mathf.Rad2Deg;
        
        transform.localEulerAngles = 
            new Vector3(Mathf.Clamp(_barrelStandardAngleX + angleToTarget, _minAngleX, _maxAngleX), 0, 0);
    }
}
