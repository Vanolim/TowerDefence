using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private HeroMove _heroMove;
    [SerializeField] private HeroUse _heroUse;
    [SerializeField] private HeroAnimator _heroAnimator;
    [SerializeField] private AnimationAlongMove _animationAlongMove;
    
    public void Init(IInputService inputService)
    {
        _heroMove.Init(inputService);
        _animationAlongMove.Init(_heroMove, _heroAnimator);
    }
}
