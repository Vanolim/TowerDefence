using UnityEngine;

public class EnemyPath
{
    private readonly Path _path;
    private Waypoint _currentWaypoint;
    private SpawnWaypoint _spawnWaypoint;

    public Transform SpawnPosition => _spawnWaypoint.transform;

    public EnemyPath(Path path)
    {
        _path = path;
        Init();
    }

    private void Init()
    {
        _spawnWaypoint = _path.SpawnWaypoint;
        _currentWaypoint = _spawnWaypoint;
    }

    public bool CheckCurrentWaypointTheEnd()
    {
        if (_currentWaypoint.WaypointType == WaypointType.End)
        {
            EndWaypoint endWaypoint = _currentWaypoint.GetComponent<EndWaypoint>();
            PlayEffectEndWaypoint(endWaypoint);
            return true;
        }
        return false;
    }

    private void PlayEffectEndWaypoint(EndWaypoint endWaypoint)
    {
        endWaypoint.PlayParticle();
        endWaypoint.PlaySound();
    }

    public Vector3 GetNextWaypoint()
    {
        Waypoint nextWaypoint = _path.GetNextWaypoint(_currentWaypoint);
        _currentWaypoint = nextWaypoint;
        return nextWaypoint.transform.position;
    }
}