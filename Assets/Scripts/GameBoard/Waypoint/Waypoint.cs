using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Waypoint _nextWaypoint;
    [SerializeField] private EndWaypoint _endWaypoint;
    public WaypointType WaypointType;
    public Waypoint NextWaypoint => _nextWaypoint;
    public EndWaypoint GetEndWaypoint => _endWaypoint;
    public WaypointType GetTypeWaypoint() => WaypointType;
}