using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimator : MonoBehaviour, IHeroAnimationStateReader
{
    private Animator _animator;

    private readonly int _dizzy = Animator.StringToHash("Dizzy");
    private readonly int _attack = Animator.StringToHash("Attack1");
    private readonly int _dieRecovery = Animator.StringToHash("DieRecovery");
    private readonly int _getHit = Animator.StringToHash("GetHit");
    private readonly int _victory = Animator.StringToHash("Victory");
    private readonly int _isMoving = Animator.StringToHash("IsMoving");
    private readonly int _attackStateHash = Animator.StringToHash("attack_1");
    private readonly int _dizzyStateHash = Animator.StringToHash("dizzy");
    private readonly int _movingStateHash = Animator.StringToHash("move");
    private readonly int _idleStateHash = Animator.StringToHash("idle");

    public HeroAnimatorState State { get; private set; }

    public event Action<HeroAnimatorState> StateEntered;
    public event Action<HeroAnimatorState> StateExit;

    private void Awake() => _animator = GetComponent<Animator>();
    
    public void PlayHit() => _animator.SetTrigger(_getHit);
    public void PlayDizzy() => _animator.SetTrigger(_dizzy);
    public void PlayAttack() => _animator.SetTrigger(_attack);
    public void PlayVictory() => _animator.SetTrigger(_victory);
    public void PlayDieRecovery() => _animator.SetTrigger(_dieRecovery);
    public void StopPlayMove() =>  _animator.SetBool(_isMoving, false);

    public void PlayMove() => _animator.SetBool(_isMoving, true);
    public void StopMove() => _animator.SetBool(_isMoving, false);

    public void EnteredState(int stateHash)
    {
        State = StateFor(stateHash);
        StateEntered?.Invoke(State);
    }

    private HeroAnimatorState StateFor(int stateHash)
    {
        HeroAnimatorState state;

        if (stateHash == _attackStateHash)
            state = HeroAnimatorState.Attack;
        else if (stateHash == _dizzyStateHash)
            state = HeroAnimatorState.Dizzy;
        else if (stateHash == _movingStateHash)
            state = HeroAnimatorState.Move;
        else if (stateHash == _idleStateHash)
            state = HeroAnimatorState.Idle;
        else
            state = HeroAnimatorState.Unknown;
        
        return state;
    }

    public void ExitState(int stateHash)
    {
        StateExit?.Invoke(State);
    }
}