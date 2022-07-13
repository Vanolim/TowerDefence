using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBoard
{
    private SpawnWaypoint[] _spawnWaypoints;
    private TowerPlaceForSale[] _placesForSell;
    private List<Path> _paths;

    public SpawnWaypoint[] SpawnWaypoints => _spawnWaypoints;
    public TowerPlaceForSale[] PlacesForSell => _placesForSell;

    public GameBoard() => Init();

    private void Init()
    {
        FindObjectsOnScene();
        InitPaths();
    }

    private void FindObjectsOnScene()
    {
        _spawnWaypoints = FindObjects<SpawnWaypoint>();
        _placesForSell = FindObjects<TowerPlaceForSale>();
    }

    private T[] FindObjects<T>() where T : MonoBehaviour
    {
        return GameObject.FindObjectsOfType<T>();
    }

    private void InitPaths()
    {
        _paths = new List<Path>();
        foreach (var spawnTile in _spawnWaypoints)
        {
            _paths.Add(new Path(spawnTile));
        }
    }

    public Path GetPath(SpawnWaypoint spawnWaypoint) => _paths.FirstOrDefault(path => path.SpawnWaypoint == spawnWaypoint);
}