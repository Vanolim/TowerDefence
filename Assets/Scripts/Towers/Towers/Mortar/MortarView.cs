using UnityEngine;

public class MortarView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void PlayAnimationShoot()
    {
        _animator.SetTrigger("Shoot");
    }
}
