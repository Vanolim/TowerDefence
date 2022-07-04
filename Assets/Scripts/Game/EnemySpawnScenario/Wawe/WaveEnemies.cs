using System;
using System.Collections.Generic;
using UnityEngine;

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

        _timeLevel += Time.deltaTime;
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

    public EnemyTypeId TryGetEnemy()
    {
        GroupEnemies group = GroupsEnemies[_currentGroup];

        if (group.IsEmpty)
        {
            _timeLastSpawn = 0;
            _currentGroup++;
            if (_currentGroup >= GroupsEnemies.Count)
                _isEmpty = true;
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

        _timeLastSpawn += Time.deltaTime;
       return EnemyTypeId.None;
    }
}
