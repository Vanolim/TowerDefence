public class Cannon : Tower
{
    protected override void UpdateState()
    {
        if (IsTargetSet)
        {
            if (IsTargetActive())
            {
                RotateBodyOnTarget();
                RotateBarrelOnTarget();
                if(IsRecharged())
                    Shoot();
            }
        }
        else
        {
            if (TryFindNewTarget())
                StopBodyRotateRandomly();
            else
                RotateBodyAroundRandomly();
        };
    }
}
