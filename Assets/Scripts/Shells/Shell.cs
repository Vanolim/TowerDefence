using System;
using UnityEngine;

public abstract class Shell : MonoBehaviour
{
    private ShellStaticData _staticData;

    protected int EnemyLayerMask;
    protected TargetPoint TargetPoint;
    protected Vector3 LaunchVelocity;

    protected const float HIT_REGISTRATION_ERROR = 1f;
    private const float GROUND_HEIGHT = 0.12f;
    private const string TARGET_LAYER_NAME = "Enemy";

    public event Action<Shell> OnDestroyed;

    public abstract void Tick(float dt);
    protected abstract void Init();
    
    public void Init(TargetPoint target)
    {
        TargetPoint = target;
        Init();
    }
    
    public void Init(Vector3 launchVelocity)
    {
        LaunchVelocity = launchVelocity;
        Init();
    }

    public void SetStaticData(ShellStaticData staticData)
    {
        IniLayerMask();
        _staticData = staticData;
    }

    private void IniLayerMask()
    {
        EnemyLayerMask = 1 << LayerMask.NameToLayer(TARGET_LAYER_NAME);
    }

    protected void Recycle()
    {
        OnDestroyed?.Invoke(this);
    }
    
    protected void TurnToTarget()
    {
        transform.LookAt(TargetPoint.Position);
    }

    protected void ToDamageEnemy(Enemy enemy)
    {
        enemy.TakeDamage(_staticData.Damage);
    }

    protected void MoveForward(float dt)
    {
        transform.Translate(Vector3.forward * (_staticData.Speed * dt));
    }

    protected bool CheckingReachedGround() => transform.position.y <= GROUND_HEIGHT;
    protected void Destroyed() => Destroy(gameObject);
}
