using System.Collections.Generic;

public class Path
{
    private readonly List<Waypoint> _waypoints;
    private readonly SpawnWaypoint _spawnWaypoint;
    private EndWaypoint _endWaypoint;

    public SpawnWaypoint SpawnWaypoint => _spawnWaypoint;
    public EndWaypoint EndWaypoint => _endWaypoint;

    public Path(SpawnWaypoint spawnWaypoint)
    {
        _waypoints = new List<Waypoint>();
        _spawnWaypoint = spawnWaypoint;
        Init();
    }

    private void Init()
    {
        _waypoints.Add(_spawnWaypoint);
        while (true)
        {
            Waypoint lastIndex = _waypoints[_waypoints.Count - 1];
            if (lastIndex.GetTypeWaypoint() == WaypointType.End)
            {
                _endWaypoint = lastIndex.GetComponent<EndWaypoint>();
                break;
            }
            _waypoints.Add(lastIndex.NextWaypoint);
        }
    }

    public Waypoint GetNextWaypoint(Waypoint currentWaypoint) => currentWaypoint.NextWaypoint;
}
