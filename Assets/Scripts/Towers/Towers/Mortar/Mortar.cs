using UnityEngine;

public class Mortar : Tower
{
    [SerializeField] private MortarView _mortarView;
    
    private bool IsShoots = false;
    
    protected override void UpdateState()
    {
        if(TryTrackTarget())
        {
            RotateBody();
            if (IsRecharged())
            {
                if (IsShoots == false)
                {
                    _mortarView.PlayAnimationShoot();
                    IsShoots = true;
                }
            }
        }
        else
        {
            RotateBodyRandomly();
        }
    }

    //the method is called on the Shoot(Mortar) animation event
    public void ThrowMine()
    {
        ShootParabolicTrajectory();
        IsShoots = false;
    }
}
