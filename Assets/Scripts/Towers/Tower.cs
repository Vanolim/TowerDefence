using System.Collections;
using UnityEngine;

[SelectionBase]
public abstract class Tower : MonoBehaviour
{
    [SerializeField] private AudioSource _shootSound;
    
    private float _targetingRange;
    private float _rechargeTime;
    
    private TowerGun _towerGun;
    private TargetPoint _target;
    private Vector3 _targetPosition;
    
    private float _distanceToTarget;
    private float _shootTimer;
    private float _randomAngleValue;
    private bool _isWorkGetRandomAngleValue = false;
    
    private IEnumerator _workGetRandomAngleValue;
    
    private const int ENEMY_LAYER_MASK = 1 << 8;
    private const int TurningSpeed = 500;

    protected TargetPoint Target => _target;

    public void Init(SpawnerShell spawnerShell)
    {
        _towerGun = transform.GetComponentInChildren<TowerGun>();
        _towerGun.Init(spawnerShell, _targetingRange);
        _workGetRandomAngleValue = GetRandomAngleValue();
    }

    public void Init(TowerStaticData towerStaticData)
    {
        _targetingRange = towerStaticData.TargetingRange;
        _rechargeTime = towerStaticData.RechargeTime;
    }
    
    public void GameUpdate()
    {
        UpdateState();
    }

    protected abstract void UpdateState();

    protected bool TryTrackTarget()
    {
        if (_target != null && _target.gameObject.layer != ENEMY_LAYER_MASK)
            _target = null;
        
        if (_target == null)
        {
            if (TryFindTarget() == false)
                return false;
        }
        Vector3 towerPosition = transform.position;
        _targetPosition = _target.Position;
        _distanceToTarget = Vector3.Distance(towerPosition, _targetPosition);
        if (_distanceToTarget > _targetingRange + _target.ColliderSize)
        {
            _target = null;
            return false;
        }
        StopCoroutine(_workGetRandomAngleValue);
        _isWorkGetRandomAngleValue = false;
        return true;
    }

    private bool TryFindTarget()
    {
        float targetingRange = _targetingRange / 4;
        for (int i = 0; i < 4; i++)
        {
            if (TruFindEnemySphere(targetingRange))
                return true;
            targetingRange += _targetingRange / 4;
        }

        return false;
    }

    private bool TruFindEnemySphere(float targetingRange)
    {
        int maxCountEnemies = 1;
        Collider[] enemies = new Collider[maxCountEnemies];
        Physics.OverlapSphereNonAlloc(transform.position, targetingRange, enemies, ENEMY_LAYER_MASK);
       
        if (enemies[0] != null && _target == null)
        {
            _target = enemies[0].GetComponent<TargetPoint>();
        }

        return _target != null;
    }

    protected void Shoot()
    {
        _towerGun.Shoot(_target);
        _shootTimer = 0;
        _shootSound.Play();
    }

    protected void ShootParabolicTrajectory()
    {
        _towerGun.ShootParabolicTrajectory(_targetPosition);
        _shootTimer = 0;
        _shootSound.Play();
    }

    protected bool IsRecharged()
    {
        _shootTimer += Time.deltaTime;
        if (_shootTimer >= _rechargeTime)
        {
            return true;
        }

        return false;
    }

    protected void RotateBody()
    {
        Vector3 targetDirection = _target.transform.position - transform.position;
        targetDirection.y = 0.0f;
        TurnBodyAround(Quaternion.LookRotation(targetDirection));
    }

    protected void RotateBodyRandomly()
    {
        if (_isWorkGetRandomAngleValue == false)
        {
            StartCoroutine(_workGetRandomAngleValue);
            _isWorkGetRandomAngleValue = true;
        }
        Vector3 transformEulerAngles = transform.eulerAngles;
        transformEulerAngles.y = _randomAngleValue;
        TurnBodyAround(Quaternion.Euler(transformEulerAngles), 0.1f);
    }

    private void TurnBodyAround(Quaternion around, float slowlyDown = 1f)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, around, 
            Time.deltaTime * TurningSpeed * slowlyDown);
    }

    protected void RotateBarrel()
    {
        _towerGun.TurnToTarget(_target.Position, _distanceToTarget);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 position = transform.position;
        position.y += 0.1f;
        Gizmos.DrawWireSphere(position, _targetingRange);
        if (_target != null)
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawLine(transform.position, _target.Position);
        }
    }
    
    private IEnumerator GetRandomAngleValue()
    {
        WaitForSeconds sleep = new WaitForSeconds(Random.Range(2f, 5f));
        while (true)
        {
            _randomAngleValue = Random.Range(0, 360);
            yield return sleep;
        }
    }
}
