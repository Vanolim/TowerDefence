using UnityEngine;

public class SpawnerTowerPlace
{
    private Transform _container;
    private readonly IGameFactory _gameFactory;
    
    private const string ContainerTag = "SpawnerTowerPlaceContainer";
    public SpawnerTowerPlace(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;
        
        FindContainer();
    }

    private void FindContainer()
    {
        _container = GameObject.FindWithTag(ContainerTag).transform;
    }


    public void Spawn(IGoodsView towerPlaceForSale)
    {
        TowerPlace towerPlace = _gameFactory.CreateTowerPlace(towerPlaceForSale.GetTransformObject(), _container);
        GameObject.Destroy(towerPlaceForSale.GetTransformObject().gameObject);
        towerPlace.gameObject.transform.position = towerPlaceForSale.GetTransformObject().position;
    }
}
