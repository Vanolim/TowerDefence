public interface ISaveLoad : IService
{
    public void SaveLevelPass(string sceneName, bool isLevelPass);
    public int LoadLevelPass(string levelName);
    public bool IsKeyHave(string levelName);
    public void SetNewKey(string levelName);
}