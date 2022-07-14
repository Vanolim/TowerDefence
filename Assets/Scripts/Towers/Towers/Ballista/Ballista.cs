public class Ballista : Tower
{
    protected override void UpdateState()
    {
        if (IsTargetSet)
        {
            if (IsTargetActive())
            {
                RotateBodyOnTarget();
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
