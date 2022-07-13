using UnityEngine;

public class SpawnWaypoint : Waypoint
{
    [SerializeField] private ParticleSystem _particleSpawn;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SpawnWaypointUniqueId _spawnWaypointUniqueId;

    public string GetId() => _spawnWaypointUniqueId.Id;

    public void PlaySpawnEffect()
    {
        _particleSpawn.Play();
        _audioSource.Play();
    }
}
