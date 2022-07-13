using System;
using UnityEngine;

public class SpawnerShell
{
    private Transform _container;
    private readonly IGameFactory _gameFactory;
    
    private const string ContainerTag = "SpawnerShellContainer";

    public event Action<Shell> OnSpawned;

    public SpawnerShell(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;

        FindContainer();
    }
    
    private void FindContainer()
    {
        _container = GameObject.FindWithTag(ContainerTag).transform;
    }

    public void Spawn(Transform launchPoint, TargetPoint targetPoint, ShellTypeId shellTypeId)
    {
        Shell instantiate = GetShell(launchPoint, shellTypeId);
        instantiate.Init(targetPoint);
        OnSpawned?.Invoke(instantiate);
    }

    public void Spawn(Transform launchPoint, Vector3 launchVelocity, ShellTypeId shellTypeId)
    {
        Shell instantiate = GetShell(launchPoint, shellTypeId);
        instantiate.Init(launchVelocity);
        OnSpawned?.Invoke(instantiate);
    }

    private Shell GetShell(Transform launchPoint, ShellTypeId shellTypeId)
    {
        Shell shell = _gameFactory.CreateShell(shellTypeId, _container);
        shell.transform.position = launchPoint.position;
        shell.transform.rotation = launchPoint.rotation;
        return shell;
    }
}
