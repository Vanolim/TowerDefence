using UnityEngine;

public class Arrow : Shell
{
    [SerializeField, Range(0.5f, 5f)] private float _lifetime;
    private float _lifeCounter = 0f;

    protected override void Init()
    {
        
    }

    public override void Tick(float dt)
    {
        _lifeCounter += dt;
        if (_lifeCounter >= _lifetime)
        {
            Recycle();
            Destroyed();
            return;
        }

        MoveForward(dt);
        if (CheckingReachedGround())
        {
            Recycle();
            Destroyed();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out TargetPoint target))
        {
            ToDamageEnemy(target.Enemy);
        }
    }
}
