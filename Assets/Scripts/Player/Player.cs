public class Player : IDisposable
{
    public Wallet Wallet { get; }
    public Health Health { get; }
    public PlayerLose PlayerLose { get; }
    public PlayerVictory PlayerVictory { get; }
    
    private const int INITIAL_HEALTH = 3;
    
    public Player(ILevelData levelData, IPauseHandler pauseHandler, IAudioPlayer audioPlayer)
    {
        Wallet = new Wallet(levelData.CountInitialBalance, audioPlayer);
        Health = new Health(INITIAL_HEALTH, audioPlayer);
        PlayerLose = new PlayerLose(Health, pauseHandler, audioPlayer);
        PlayerVictory = new PlayerVictory(pauseHandler, audioPlayer);
    }

    public void Dispose()
    {
        Wallet.Dispose();
        PlayerLose.Dispose();
    }
}