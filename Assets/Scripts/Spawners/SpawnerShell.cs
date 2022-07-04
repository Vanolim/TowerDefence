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

    public void Spawn(Vector3 launchPoint, TargetPoint targetPoint, ShellTypeId shellTypeId)
    {
        Shell instantiate = GetShell(launchPoint, shellTypeId);
        instantiate.Init(targetPoint, this);
        OnSpawned?.Invoke(instantiate);
    }

    public void Spawn(Vector3 launchPoint, Vector3 launchVelocity, ShellTypeId shellTypeId)
    {
        Shell instantiate = GetShell(launchPoint, shellTypeId);
        instantiate.Init(launchVelocity, this);
        OnSpawned?.Invoke(instantiate);
    }

    private Shell GetShell(Vector3 launchPoint, ShellTypeId shellTypeId)
    {
        Shell shell = _gameFactory.CreateShell(shellTypeId, _container);
        shell.transform.position = launchPoint;
        return shell;
    }

    public void Reclaim(Shell shell) => GameObject.Destroy(shell.gameObject);
}
