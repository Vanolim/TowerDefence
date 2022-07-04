using System;

[Serializable]
public class GroupEnemies
{
    private bool _isStarted = false;
    
    public EnemyTypeId TypeId;
    public int CountEnemyInGroup;
    public float TimeBetweenSpawnEnemy;
    public float WaitingBeforeSpawn;

    public bool IsStarted => _isStarted;
    public bool IsEmpty => CountEnemyInGroup == 0;

    public EnemyTypeId GetEnemy()
    {
        _isStarted = true;
        CountEnemyInGroup--;
        return TypeId;
    }
}
