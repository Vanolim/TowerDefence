using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Transform _container;

    public readonly Dictionary<LevelViewButton, string> LevelViewButtons = new Dictionary<LevelViewButton, string>();

    public Transform Container => _container;

    public void AddLoadLevelButton(LevelViewButton levelViewButton, string sceneName)
    {
        LevelViewButtons.Add(levelViewButton, sceneName);
    }
}