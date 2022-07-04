public class PlayerLogic : IDisposable
{
    private TowerPlaceBuyHandler TowerPlaceBuyHandler { get; }
    private TowerBuyHandler TowerBuyHandler { get; }
    private CrystalMineBuyHandler CrystalMineBuyHandler { get; }
     

    public PlayerLogic(PurchaseRadialViewHandler purchaseRadialViewHandler, GameBoard gameBoard, Spawners spawners, 
        IStaticDataService staticDataService, IInputHandler inputHandler, ILevelData levelData, IAudioPlayer audioPlayer)
    {
        TowerPlaceBuyHandler = new TowerPlaceBuyHandler(purchaseRadialViewHandler, gameBoard, spawners.SpawnerTowerPlace, inputHandler, levelData, audioPlayer);
        TowerBuyHandler = new TowerBuyHandler(purchaseRadialViewHandler, staticDataService, spawners.SpawnerTower, levelData, inputHandler, audioPlayer);
        CrystalMineBuyHandler = new CrystalMineBuyHandler(purchaseRadialViewHandler, spawners.SpawnerCrystalMine, levelData, inputHandler, audioPlayer);
    }

    public void Dispose()
    {
        TowerPlaceBuyHandler.Dispose();
        TowerBuyHandler.Dispose();
        CrystalMineBuyHandler.Dispose();
    }
}