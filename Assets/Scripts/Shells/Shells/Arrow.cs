using UnityEngine;

public class Arrow : Shell
{
    [SerializeField, Range(0.5f, 5f)] private float _lifetime;
    private float _lifeCounter = 0f;

    public override bool GameUpdate()
    {
        _lifeCounter += Time.deltaTime;
        if (_lifeCounter >= _lifetime)
        {
            Recycle();
            return false;
        }

        MoveForward();
        if (CheckingReachedGround())
        {
            Recycle();
            return false;
        }
        return true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out TargetPoint target))
        {
            ToDamage(target.Enemy);
        }
    }
}
