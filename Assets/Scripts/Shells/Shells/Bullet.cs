public class Bullet : Shell
{
    public override bool GameUpdate()
    {
        if (IsEnemyPosition(transform.position))
        {
            ToDamage();
            Recycle();
            return false;
        }

        MoveForward();
        return true;
    }
}
