using UnityEngine;

public class SpawnerCrystalMine
{
    private const string ContainerTag = "SpawnerCrystalMineContainer";
    
    private Transform _container;

    private readonly IGameFactory _gameFactory;
    private readonly Wallet _wallet;
    private readonly IPauseHandler _pauseHandler;

    public SpawnerCrystalMine(IGameFactory gameFactory, Wallet wallet, IPauseHandler pauseHandler)
    {
        _gameFactory = gameFactory;
        _wallet = wallet;
        _pauseHandler = pauseHandler;

        FindContainer();
    }

    private void FindContainer()
    {
        _container = GameObject.FindWithTag(ContainerTag).transform;
    }

    public CrystalMineWorking SpawnCrystalWorking(Transform pastMine)
    {
        CrystalMineWorking mine = _gameFactory.CreateMine(pastMine, _container);
        _pauseHandler.Register(mine);
        _wallet.AddProduce(mine);
        return mine;
    }

    public void Reclaim(CrystalMineWorking mine) => GameObject.Destroy(mine.gameObject);
}