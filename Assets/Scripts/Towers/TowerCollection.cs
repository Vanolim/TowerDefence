using System.Collections.Generic;

public class TowerCollection : ITickable, IDisposable
{
    private readonly SpawnerTower _spawnerTower;
    private readonly List<Tower> _towers = new List<Tower>();

    public TowerCollection(SpawnerTower spawnerTower)
    {
        _spawnerTower = spawnerTower;
        _spawnerTower.OnSpawned += Add;
    }

    private void Add(Tower tower)
    {
        _towers.Add(tower);
    }

    public void Tick()
    {
        foreach (var tower in _towers)
        {
            tower.GameUpdate();
        }
    }

    public void Dispose()
    {
        _spawnerTower.OnSpawned -= Add;
    }
}
