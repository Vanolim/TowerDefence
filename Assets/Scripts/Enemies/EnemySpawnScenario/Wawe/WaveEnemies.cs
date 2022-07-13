using System;
using System.Collections.Generic;

[Serializable]
public class WaveEnemies
{
    public string SpawnWaypointId;
    public List<GroupEnemies> GroupsEnemies = new List<GroupEnemies>();
    public float TimeAppearance;

    private float _timeLastSpawn;
    private bool _waveActive = false;
    private bool _isEmpty;
    private int _currentGroup;
    private float _timeLevel;
    private float _dt;

    public bool IsEmpty => _isEmpty || GroupsEnemies.Count == 0;

    public bool WaveActive
    {
        get
        {
            if (_waveActive)
                return true;
            if (IsTimeAppearance())
            {
                _waveActive = true;
                return true;
            }

            return false;
        }
    }

    private bool IsTimeAppearance()
    {
        if (_timeLevel >= TimeAppearance)
        {
            _waveActive = true;
            return true;
        }

        _timeLevel += _dt;
        return false;
    }

    public void AddGroup()
    {
        GroupsEnemies.Add(new GroupEnemies());
    }

    public void DeleteGroup(GroupEnemies group)
    {
        GroupsEnemies.Remove(group);
    }

    public void SetDeltaTime(float dt) => _dt = dt;

    public EnemyTypeId TryGetEnemy()
    {
        GroupEnemies group = GroupsEnemies[_currentGroup];

        if (group.IsEmpty)
        {
            ChangeGroup();
            return EnemyTypeId.None;
        }

        if (group.IsStarted == false && _timeLastSpawn >= group.WaitingBeforeSpawn)
        {
            _timeLastSpawn = 0;
            return group.GetEnemy();
        }

        if (group.IsStarted && _timeLastSpawn > group.TimeBetweenSpawnEnemy)
        {
            _timeLastSpawn -= group.TimeBetweenSpawnEnemy;
            return group.GetEnemy();
        }

        _timeLastSpawn += _dt;
       return EnemyTypeId.None;
    }

    private void ChangeGroup()
    {
        _timeLastSpawn = 0;
        _currentGroup++;
        if (CheckGroupIsLast())
            _isEmpty = true;
    }
    private bool CheckGroupIsLast() => _currentGroup >= GroupsEnemies.Count;
}
