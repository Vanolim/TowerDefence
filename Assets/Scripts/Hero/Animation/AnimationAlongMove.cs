public class AnimationAlongMove : ITickable
{
    private HeroMove _heroMove;
    private HeroAnimator _heroAnimator;

    private bool _isMove;

    public AnimationAlongMove(HeroMove heroMove, HeroAnimator heroAnimator)
    {
        _heroMove = heroMove;
        _heroAnimator = heroAnimator;
    }

    public void Tick(float dt)
    {
        bool isMove = _heroMove.IsMove;

        if (_isMove != isMove)
        {
            if(isMove)
                _heroAnimator.PlayMove();
            else
                _heroAnimator.StopMove();

            _isMove = isMove;
        }
    }
}
