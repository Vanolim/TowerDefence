using System;

public class ViewHandlers : IDisposable
{
    public event Action OnReturnLevel;
    public event Action OnExitMenu;

    public EndViewHandler EndViewHandler { get; }
    public PurchaseRadialViewHandler PurchaseRadialViewHandler { get; }
    public PauseViewHandler PauseViewHandler { get; }

    public ViewHandlers(LevelSceneContextUI levelSceneContextUI, Player player, IPauseHandler pauseHandler, IAudioPlayer audioPlayer)
    {
        PurchaseRadialViewHandler = new PurchaseRadialViewHandler(levelSceneContextUI.SellView, player.Wallet, audioPlayer);
        EndViewHandler = new EndViewHandler(levelSceneContextUI.EndView, player.PlayerLose, player.PlayerVictory, audioPlayer);
        PauseViewHandler = new PauseViewHandler(levelSceneContextUI.PauseView, levelSceneContextUI.Pause, pauseHandler, audioPlayer);

        Subscribe();
    }

    private void Subscribe()
    {
        EndViewHandler.OnReturn += ReturnLevel;
        EndViewHandler.OnMenu += ExitMenu;
        PauseViewHandler.OnReturn += ReturnLevel;
        PauseViewHandler.OnMenu += ExitMenu;
    }

    private void ReturnLevel() => OnReturnLevel?.Invoke();
    private void ExitMenu() => OnExitMenu?.Invoke();
    public void Dispose()
    {
        Unsubscribe();
        
        PurchaseRadialViewHandler.Dispose();
        EndViewHandler.Dispose();
        PauseViewHandler.Dispose();
    }

    private void Unsubscribe()
    {
        EndViewHandler.OnReturn -= ReturnLevel;
        EndViewHandler.OnMenu -= ExitMenu;
        PauseViewHandler.OnReturn -= ReturnLevel;
        PauseViewHandler.OnMenu -= ExitMenu;
    }
}