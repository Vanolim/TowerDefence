using System;
using UnityEngine;

public class SpawnerTower
{
    private Transform _container;
    private readonly SpawnerShell _spawnerShell;
    private readonly IGameFactory _gameFactory;

    private const string ContainerTag = "SpawnerTowerContainer";

    public event Action<Tower> OnSpawned;

    public SpawnerTower(IGameFactory gameFactory, SpawnerShell spawnerShell)
    {
        _gameFactory = gameFactory;
        _spawnerShell = spawnerShell;

        FindContainer();
    }

    private void FindContainer()
    {
        _container = GameObject.FindWithTag(ContainerTag).transform;
    }

    public void Spawn(TowerTypeId typeId, IGoodsView towerPlace)
    {
        Tower tower = _gameFactory.CreateTower(typeId, _container);
        tower.Init(_spawnerShell);
        tower.gameObject.transform.position = towerPlace.GetTransformForSpawn().position;
        OnSpawned?.Invoke(tower);
    }
}
