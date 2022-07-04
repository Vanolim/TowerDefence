using UnityEngine;

public class EndWaypoint : Waypoint
{
    [SerializeField] private ParticleSystem _particleEnd;
    [SerializeField] private AudioSource _audio;

    public void PlayParticle() => _particleEnd.Play();

    public void PlaySound() => _audio.Play();
}