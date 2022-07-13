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

    public void Tick(float dt)
    {
        foreach (var tower in _towers)
        {
            tower.Tick(dt);
        }
    }

    public void Dispose()
    {
        _spawnerTower.OnSpawned -= Add;
    }
}
