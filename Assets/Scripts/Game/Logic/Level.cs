using UnityEngine;

public class Level : IDisposable
{
    public EnemySpawnScenario EnemySpawnScenario { get; }
    private ExitLevel ExitLevel { get; }
    public Level(GameBoard gameBoard, PlayerVictory playerVictory, ILevelData levelData, ViewHandlers viewHandlers,
        IEndLevelHandler endLevelHandler, ICloseState level)
    {
        EnemySpawnScenario = new EnemySpawnScenario(gameBoard, levelData);
        ExitLevel = new ExitLevel(viewHandlers, playerVictory, endLevelHandler, level);
    }

    public void Dispose()
    {
        ExitLevel.Dispose();
    }
}