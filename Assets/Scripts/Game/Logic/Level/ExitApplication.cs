using UnityEngine.UI;

public class ExitApplication : IDisposable
{
      private Button _exitButton;
      private readonly IExitApplicationHandler _exitApplicationHandler;
      
      public ExitApplication(Button exitButton, IExitApplicationHandler exitApplicationHandler)
      {
            _exitButton = exitButton;
            _exitApplicationHandler = exitApplicationHandler;
            exitButton.onClick.AddListener(Exit);
      }

      private void Exit() => _exitApplicationHandler.Exit();

      public void Dispose()
      {
            _exitButton.onClick.RemoveListener(Exit);
      }
}