public class BallistaGun : TowerGun
{
    protected override void Init()
    {
        
    }

    public override void Shoot(TargetPoint targetPoint)
    {
        SpawnerShell.Spawn(LaunchPoint, targetPoint, shellTypeId);
    }
}
