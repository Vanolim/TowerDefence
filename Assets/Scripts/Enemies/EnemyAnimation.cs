using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private const string HIT_TRIGGER = "GetHit";
    private const string DIE_TRIGGER = "Die";
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayHit()
    {
        _animator.SetTrigger(HIT_TRIGGER);
    }

    public void PlayDead()
    {
        _animator.SetTrigger(DIE_TRIGGER);
    }
}