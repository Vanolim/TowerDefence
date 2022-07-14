using UnityEngine;

public class Bullet : Shell
{
    protected override void Init()
    {
        TurnToTarget();
    }

    public override void Tick(float dt)
    {
        if (IsEnemyPosition())
        {
            ToDamageEnemy(TargetPoint.Enemy);
            Recycle();
            Destroyed();
            return;
        }

        MoveForward(dt);
    }

    private bool IsEnemyPosition()
    {
        if (Vector3.Distance(transform.position, TargetPoint.Position) <= HIT_REGISTRATION_ERROR)
            return true;
        return false;
    }
}
