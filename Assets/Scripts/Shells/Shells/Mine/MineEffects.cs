using UnityEngine;

public class MineEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _core;
    [SerializeField] private ParticleSystem _smoke;
    [SerializeField] private AudioSource _sound;

    public void PlayEffects()
    {
        _core.Play();
        _smoke.Play();
        _sound.Play();
    }
}