using UnityEngine;

public class AnimationAlongMove : MonoBehaviour
{
    private HeroMove _heroMove;
    private HeroAnimator _heroAnimator;

    private bool _isMove;

    public void Init(HeroMove heroMove, HeroAnimator heroAnimator)
    {
        _heroMove = heroMove;
        _heroAnimator = heroAnimator;
    }

    private void Update()
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
