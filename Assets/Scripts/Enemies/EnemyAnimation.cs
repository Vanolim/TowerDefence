using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private static readonly int GetHit = Animator.StringToHash("GetHit");
    private static readonly int Die = Animator.StringToHash("Die");


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayHit()
    {
        _animator.SetTrigger(GetHit);
    }

    public void PlayDead()
    {
        _animator.SetTrigger(Die);
    }
}