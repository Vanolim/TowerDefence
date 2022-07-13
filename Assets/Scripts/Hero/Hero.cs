using UnityEngine;

public class Hero : MonoBehaviour, ITickable
{
    [SerializeField] private HeroUse _heroUse;
    [SerializeField] private HeroAnimator _heroAnimator;
    [SerializeField] private CharacterController _characterController;

    private AnimationAlongMove _animationAlongMove;
    private HeroMove _heroMove;

    public void Init(IInputService inputService)
    {
        _heroMove = new HeroMove(inputService, _characterController, transform);
        _animationAlongMove = new AnimationAlongMove(_heroMove, _heroAnimator);
        
        _heroUse.Init();
    }

    public void Tick(float dt)
    {
        _heroMove.Tick(dt);
        _animationAlongMove.Tick(dt);
    }
}
