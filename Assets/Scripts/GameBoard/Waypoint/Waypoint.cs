using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Waypoint _nextWaypoint;
    public WaypointType WaypointType;
    public Waypoint NextWaypoint => _nextWaypoint;
    public WaypointType GetTypeWaypoint() => WaypointType;
}