using UnityEngine;

public class CoreLevelLogic : IDisposable
{
    public UpdateGameWorld UpdateGameWorld { get; }
    public GameBoard GameBoard { get; }
    public Level Level { get; }
    public CoreLevelLogic(PlayerVictory playerVictory, ILevelData levelData, ViewHandlers viewHandlers, 
        IEndLevelHandler endLevelHandler, ICloseState level)
    {
        UpdateGameWorld = GameObject.FindObjectOfType<UpdateGameWorld>();
        GameBoard = new GameBoard();
        Level = new Level(GameBoard, playerVictory, levelData, viewHandlers, endLevelHandler, level);
        
        UpdateGameWorld.AddTickableItem(Level.EnemySpawnScenario);
    }

    public void Dispose()
    {
        Level.Dispose();
    }
}