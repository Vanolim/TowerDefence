using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioClip _dead;

    public void PlayHit()
    {
        _audioSource.clip = _hit;
        _audioSource.Play();
    }
    
    public void PlayDead()
    {
        _audioSource.clip = _dead;
        _audioSource.Play();
    }
}