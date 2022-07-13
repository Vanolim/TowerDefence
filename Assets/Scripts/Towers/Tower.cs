using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[SelectionBase]
public abstract class Tower : MonoBehaviour
{
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private TowerGun _towerGun;

    private TargetPoint _target;
    private TowerStaticData _staticData;

    protected bool IsTargetSet => _target != null;

    private float _distanceToTarget;
    private float _shootTimer;
    private float _randomAngleValue;
    private bool _isWorkGetRandomAngleValue = false;
    private IEnumerator _workGetRandomAngleValue;
    private float _dt;
    private int _targetLayer;


    public void Init(SpawnerShell spawnerShell)
    {
        _towerGun.Init(spawnerShell, _staticData.TargetingRange);
        _workGetRandomAngleValue = GetRandomAngleValue();
        _targetLayer = 1 << 8;
    }
    

    public void SetStaticData(TowerStaticData towerStaticData)
    {
        _staticData = towerStaticData;
    }

    public void Tick(float dt)
    {
        _dt = dt;
        UpdateState();
    }

    protected abstract void UpdateState();

    protected bool IsTargetActive()
    {
        if (CheckTargetChangedLayer())
        {
            _target = null;
            return false;
        }

        if (IsTargetInRange() == false)
        {
            _target = null;
            return false;
        }

        return true;
    }

    private bool CheckTargetChangedLayer() => 
        (1 << _target.gameObject.layer) != _targetLayer;

    private bool IsTargetInRange()
    {
        _distanceToTarget = Vector3.Distance(transform.position, _target.Position);
        return !(_distanceToTarget > _staticData.TargetingRange + _target.ColliderSize);
    }

    protected bool TryFindNewTarget()
    {
        int numberSearchRangePositions = 4;
        float targetingRange = _staticData.TargetingRange / numberSearchRangePositions;
        for (int i = 0; i < numberSearchRangePositions; i++)
        {
            if (TryFindTargetSearchRadius(targetingRange))
                return true;
            
            targetingRange += _staticData.TargetingRange / numberSearchRangePositions;
        }

        return false;
    }

    private bool TryFindTargetSearchRadius(float searchRadius)
    {
        int maxCountEnemies = 1;
        Collider[] enemies = new Collider[maxCountEnemies];
        Physics.OverlapSphereNonAlloc(transform.position, searchRadius, enemies, _targetLayer);
        

        if (enemies[0] != null) 
            _target = enemies[0].GetComponent<TargetPoint>();

        return _target != null;
    }

    protected void Shoot()
    {
        _towerGun.Shoot(_target);
        _shootTimer = 0;
        _shootSound.Play();
    }

    protected bool IsRecharged()
    {
        _shootTimer += _dt;
        return _shootTimer >= _staticData.RechargeTime;
    }

    protected void RotateBodyOnTarget()
    {
        Vector3 targetDirection = _target.transform.position - transform.position;
        targetDirection.y = 0.0f;
        TurnBodyAround(Quaternion.LookRotation(targetDirection));
    }

    protected void StopBodyRotateRandomly()
    {
        StopCoroutine(_workGetRandomAngleValue);
        _isWorkGetRandomAngleValue = false;
    }

    protected void RotateBodyAroundRandomly()
    {
        if (_isWorkGetRandomAngleValue == false)
        {
            StartCoroutine(_workGetRandomAngleValue);
            _isWorkGetRandomAngleValue = true;
        }

        float slowlyDown = 0.1f;
        Vector3 transformEulerAngles = transform.eulerAngles;
        transformEulerAngles.y = _randomAngleValue;
        TurnBodyAround(Quaternion.Euler(transformEulerAngles), slowlyDown);
    }

    private void TurnBodyAround(Quaternion around, float slowlyDown = 1f)
    {
        int urningSpeed = 500;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, around, 
            _dt * urningSpeed * slowlyDown);
    }

    protected void RotateBarrelOnTarget()
    {
        _towerGun.TurnToTarget(_target.Position, _distanceToTarget);
    }

    private IEnumerator GetRandomAngleValue()
    {
        float minSleepTime = 2f;
        float maxSleepTime = 5f;
        WaitForSeconds sleep = new WaitForSeconds(Random.Range(minSleepTime, maxSleepTime));
        while (true)
        {
            _randomAngleValue = Random.Range(0, 360);
            yield return sleep;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 position = transform.position;
        position.y += 0.1f;
        Gizmos.DrawWireSphere(position, _staticData.TargetingRange);
        if (_target != null)
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawLine(transform.position, _target.Position);
        }
    }
}
