using System;
using UnityEngine;

public class MortarGun : TowerGun
{
    private float _launchSpeed;
    
    public override void Shoot(TargetPoint targetPoint)
    {
        SpawnerShell.Spawn(LaunchPoint, GetParabolicTrajectory(targetPoint.Position), shellTypeId);
    }

    protected override void Init()
    {
        CalculateStartParabolicTrajectory();
    }

    private void CalculateStartParabolicTrajectory()
    {
        float x = TargetingRange;
        float y = transform.position.y;
        _launchSpeed = Convert.ToSingle(Math.Sqrt(9.81f * (y + Math.Sqrt(x * x + y * y))));
    }
    
    private Vector3 GetParabolicTrajectory(Vector3 targetPosition)
    {
        Vector3 launchPoint = LaunchPoint.position;

        Vector3 targetPoint = targetPosition;
        targetPoint.y = 0;

        Vector2 dir;
        dir.x = targetPoint.x - launchPoint.x;
        dir.y = targetPoint.z - launchPoint.z;

        float x = dir.magnitude;
        float y = -launchPoint.y;
        dir /= x;

        float g = 9.81f;
        float s = _launchSpeed;
        float s2 = s * s;

        float r = s2 * s2 - g * (g * x * x + 2f * y * s2);
        float tanTheta = (s2 + Mathf.Sqrt(r)) / (g * x);
        float cosTheta = Mathf.Cos(Mathf.Atan(tanTheta));
        float sinTheta = cosTheta * tanTheta;
        
        return new Vector3(s * cosTheta *  dir.x, s * sinTheta, s * cosTheta * dir.y);
    }
}
