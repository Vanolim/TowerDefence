using UnityEngine;

public class Mortar : Tower
{
    [SerializeField] private MortarView _mortarView;
    
    private bool IsShoots = false;
    
    protected override void UpdateState()
    {
        if (IsTargetSet)
        {
            if (IsTargetActive())
            {
                RotateBodyOnTarget();
                if (IsRecharged())
                {
                    if (IsShoots == false)
                    {
                        _mortarView.PlayAnimationShoot();
                        IsShoots = true;
                    }
                }
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

    //the method is called on the Shoot(Mortar) animation event
    public void ThrowMine()
    {
        Shoot();
        IsShoots = false;
    }
}
