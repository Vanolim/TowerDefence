public class PlayerLogic : IDisposable
{
    private TowerPlaceBuyHandler TowerPlaceBuyHandler { get; }
    private TowerBuyHandler TowerBuyHandler { get; }
    private CrystalMineBuyHandler CrystalMineBuyHandler { get; }
     

    public PlayerLogic(PurchaseRadialViewHandler purchaseRadialViewHandler, GameBoard gameBoard, Spawners spawners, 
        IStaticDataService staticDataService, TouchHandler touchHandler, ILevelData levelData, IAudioPlayer audioPlayer)
    {
        TowerPlaceBuyHandler = new TowerPlaceBuyHandler(purchaseRadialViewHandler, gameBoard, spawners.SpawnerTowerPlace, touchHandler, levelData, audioPlayer);
        TowerBuyHandler = new TowerBuyHandler(purchaseRadialViewHandler, staticDataService, spawners.SpawnerTower, levelData, touchHandler, audioPlayer);
        CrystalMineBuyHandler = new CrystalMineBuyHandler(purchaseRadialViewHandler, spawners.SpawnerCrystalMine, levelData, touchHandler, audioPlayer);
    }

    public void Dispose()
    {
        TowerPlaceBuyHandler.Dispose();
        TowerBuyHandler.Dispose();
        CrystalMineBuyHandler.Dispose();
    }
}