using UnityEngine;

public class SaveLoad : ISaveLoad
{
    public void SaveLevelPass(string sceneName, bool isLevelPass)
    {
        if (PlayerPrefs.GetInt(sceneName) == 0)
        {
            if(isLevelPass)
                PlayerPrefs.SetInt(sceneName, 1);
        }
    }

    public int LoadLevelPass(string levelName) => PlayerPrefs.GetInt(levelName);
    public bool IsKeyHave(string levelName) => PlayerPrefs.HasKey(levelName);
    public void SetNewKey(string levelName) => PlayerPrefs.SetInt(levelName, 0);
}