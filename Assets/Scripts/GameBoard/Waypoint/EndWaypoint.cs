using UnityEngine;

public class EndWaypoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleEnd;
    [SerializeField] private AudioSource _audioEnd;

    public void PlayEndEffect()
    {
        _particleEnd.Play();
        _audioEnd.Play();
    }
}