using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(SpawnWaypointUniqueId))]
public class UniqueIdEditor : Editor
{
    private void OnEnable()
    {
        SpawnWaypointUniqueId spawnWaypointUniqueId = (SpawnWaypointUniqueId) target;

        if (string.IsNullOrEmpty(spawnWaypointUniqueId.Id))
            Generate(spawnWaypointUniqueId);
        else
        {
            SpawnWaypointUniqueId[] uniqueIds = FindObjectsOfType<SpawnWaypointUniqueId>();
            
            if(uniqueIds.Any(other => other != spawnWaypointUniqueId && other.Id == spawnWaypointUniqueId.Id))
                Generate(spawnWaypointUniqueId);
        }
    }

    private void Generate(SpawnWaypointUniqueId spawnWaypointUniqueId)
    {
        spawnWaypointUniqueId.Id = $"{spawnWaypointUniqueId.gameObject.scene.name}_{Guid.NewGuid().ToString()}";

        if (!Application.isPlaying)
        {
            EditorUtility.SetDirty(spawnWaypointUniqueId);
            EditorSceneManager.MarkSceneDirty(spawnWaypointUniqueId.gameObject.scene);
        }
    }
}
