using System.Collections.Generic;

public class ShellCollection : ITickable, IDisposable
{
    private readonly SpawnerShell _spawnerShell;
    private readonly List<Shell> _shells = new List<Shell>();

    public ShellCollection(SpawnerShell spawnerShell)
    {
        _spawnerShell = spawnerShell;
        _spawnerShell.OnSpawned += Add;
    }

    private void Add(Shell shell)
    {
        _shells.Add(shell);
        shell.OnDestroyed += RemoveShell;
    }

    public void Tick(float dt)
    {
        for (var i = 0; i < _shells.Count; i++)
        {
            _shells[i].Tick(dt);
        }
    }

    public void Dispose()
    {
        _spawnerShell.OnSpawned -= Add;
    }

    private void RemoveShell(Shell shell)
    {
        shell.OnDestroyed -= RemoveShell;
        _shells.Remove(shell);
    }
}
