using System.Collections.Generic;
using UnityEngine;

public class GameBoard
{
    private SpawnWaypoint[] _spawnWaypoint;
    private TowerPlaceForSale[] _placesForSell;
    private CrystalRawMine[] _crystalRawMines;
    
    private List<Path> _paths;

    public SpawnWaypoint[] SpawnWaypoints => _spawnWaypoint;
    public TowerPlaceForSale[] PlacesForSell => _placesForSell;
    public CrystalRawMine[] CrystalRawMines => _crystalRawMines;

    public GameBoard()
    {
        Init();
    }

    public void Init()
    {
        FindObjectsOnScene();
        InitPaths();
    }

    private void FindObjectsOnScene()
    {
        _spawnWaypoint = FindObjects<SpawnWaypoint>();
        _placesForSell = FindObjects<TowerPlaceForSale>();
        _crystalRawMines = FindObjects<CrystalRawMine>();
    }

    private T[] FindObjects<T>() where T : MonoBehaviour
    {
        return GameObject.FindObjectsOfType<T>();
    }

    private void InitPaths()
    {
        _paths = new List<Path>();
        foreach (var spawnTile in _spawnWaypoint)
        {
            _paths.Add(new Path(spawnTile));
        }
    }

    public Path GetPath(SpawnWaypoint spawnWaypoint)
    {
        foreach (var path in _paths)
        {
            if (path.SpawnWaypoint == spawnWaypoint)
                return path;
        }
        return null;
    }
}