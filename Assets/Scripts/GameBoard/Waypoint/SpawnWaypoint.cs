using UnityEngine;

public class SpawnWaypoint : Waypoint
{
    [SerializeField] private ParticleSystem _particleSpawn;
    [SerializeField] private AudioSource _audioSource;

    public void PlayParticle() => _particleSpawn.Play();
    public void PlayAudio() => _audioSource.Play();
}
