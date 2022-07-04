using UnityEngine;

public abstract class NotMutateSO<T> : ScriptableObject where T : ScriptableObject
{
    public T Instance
    {
        get
        {
            var instance = GetInstance();
            var json = JsonUtility.ToJson(instance);
            var newSO = CreateInstance<T>();
            JsonUtility.FromJsonOverwrite(json, newSO);
            return newSO;
        }
    }

    protected abstract T GetInstance();
}
