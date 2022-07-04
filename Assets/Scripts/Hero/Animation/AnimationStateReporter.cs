using UnityEngine;

public class AnimationStateReporter : StateMachineBehaviour
{
    private IHeroAnimationStateReader _heroAnimationStateReader;
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateExit(animator, animatorStateInfo, layerIndex);

        FindReader(animator);
        _heroAnimationStateReader.ExitState(animatorStateInfo.shortNameHash);
    }
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateExit(animator, animatorStateInfo, layerIndex);
        
        FindReader(animator);
        _heroAnimationStateReader.EnteredState(animatorStateInfo.shortNameHash);
    }

    private void FindReader(Animator animator)
    {
        if (_heroAnimationStateReader != null)
        {
            return;
        }

        _heroAnimationStateReader = animator.gameObject.GetComponent<IHeroAnimationStateReader>();
    }
}
