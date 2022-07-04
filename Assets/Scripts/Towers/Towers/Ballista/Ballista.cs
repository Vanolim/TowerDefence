public class Ballista : Tower
{
    protected override void UpdateState()
    {
        if(TryTrackTarget())
        {
            RotateBody();
            RotateBarrel();
            if(IsRecharged())
                Shoot();
        }
        else
        {
            RotateBodyRandomly();
        }
    }
}
