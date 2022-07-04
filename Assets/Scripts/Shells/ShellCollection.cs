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
    }

    public void Tick()
    {
        for (int i = 0; i < _shells.Count; i++)
        {
            if (_shells[i].GameUpdate() == false)
            {
                int lastIndex = _shells.Count - 1;
                _shells[i] = _shells[lastIndex];
                _shells.RemoveAt(lastIndex);
                i --;
            }
        }
    }

    public void Dispose()
    {
        _spawnerShell.OnSpawned -= Add;
    }
}
