using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CreateNewLevelEditor : EditorWindow
{
    private string _nameLevel = "";
    private Dictionary<WaveEnemies, bool> _displayedWavesEnemies = new Dictionary<WaveEnemies, bool>();
    private Dictionary<GroupEnemies, bool> _displayedGroupsEnemies = new Dictionary<GroupEnemies, bool>();

    private Dictionary<WaveEnemies, SpawnWaypointUniqueId> _spawnWaypoint =
        new Dictionary<WaveEnemies, SpawnWaypointUniqueId>();

    private List<TowerTypeId> _towers = new List<TowerTypeId>();
    private StaticDataService _staticDataService = new StaticDataService();

    private Object _scene;
    private int _countInitialCrystal;
    private int _towerPlacePrice;
    private int _crystalMinePrice;
    

    private bool _isDropdownWaves = true;
    private bool _isDropdownTower = true;
    private bool _isAddLevel;
    private bool _isAllWavesHaveSpawnWaypoint;

    [MenuItem("Tools/AddLevel")]
    public static void ShowWindow()
    {
        GetWindow<CreateNewLevelEditor>("AddLevel");
    }

    private void OnGUI()
    {
        if (!_isAddLevel)
            SetNewLevel();
        
        if (_isAddLevel)
            SetNewScene();

        if (_isAddLevel)
            SetWavesEnemies();
        
        if (_isAddLevel)
            SetTowers();

        if (_isAddLevel)
            SetCountInitialCrystal();

        if (_isAddLevel)
            SetTowerPlacePrice();
        
        if (_isAddLevel)
            SetCrystalMinePrice();

        if (_isAddLevel)
            SaveTheLevel();
    }

    private void SetNewScene()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        _scene = EditorGUILayout.ObjectField("Сцена уровня :", _scene, typeof(Object), true);
        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();
    }

    private void SetNewLevel()
    {
        GUILayout.Label("Enter level name", EditorStyles.boldLabel);
        _nameLevel = EditorGUILayout.TextField("Name", _nameLevel);

        if (_nameLevel.Length != 0)
        {
            EditorGUILayout.Space();
            if (GUILayout.Button($"Create {_nameLevel} level"))
            {
                string name = $"{_nameLevel}.asset";
                if (CheckAssetMatch(name))
                {
                    _isAddLevel = true;
                }
                else
                {
                    Debug.Log("the name is already in the directory");
                }
            }
        }
    }

    private bool CheckAssetMatch(string name)
    {
        string fullName = AssetPath.CreateNewLevelPath + name;
        string[] allFiles = Directory.GetFiles(AssetPath.CreateNewLevelPath);
        foreach (var item in allFiles)
        {
            if (item == fullName)
                return false;
        }

        return true;
    }

    private void SetWavesEnemies()
    {
        GUILayout.Label($"Set {_nameLevel}", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        string headerWaves = "All waves";
        _isDropdownWaves = EditorGUILayout.Foldout(_isDropdownWaves, headerWaves);
            
        if (_isDropdownWaves)
        {
            EditorGUILayout.BeginVertical("box");
            if (GUILayout.Button($"Create new wave"))
            {
                WaveEnemies wave = new WaveEnemies();
                _displayedWavesEnemies.Add(wave, true);
                _spawnWaypoint.Add(wave, null);
            
            }

            for (int i = 0; i < _displayedWavesEnemies.Count; i++)
            {
                SpawnWaypointUniqueId obj;
                KeyValuePair<WaveEnemies, bool> wave = _displayedWavesEnemies.ElementAt(i);
                
                _isAllWavesHaveSpawnWaypoint = true;

                string headerWave = $"Wave {i+1}";
                bool isDropdownWave = wave.Value;
                isDropdownWave = EditorGUILayout.Foldout(isDropdownWave, headerWave);
                _displayedWavesEnemies[wave.Key] = isDropdownWave;

                if (isDropdownWave)
                {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20)))
                    {
                        DeleteAllGroupsOfWave(wave.Key);
                        _displayedWavesEnemies.Remove(wave.Key);
                    }
                    GUILayout.Label(" - Delete wave", EditorStyles.boldLabel);
                    EditorGUILayout.EndHorizontal();
                        
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Wave spawnWaypoint:", GUILayout.Width(200));

                    SpawnWaypointUniqueId spawnWaypoint = (SpawnWaypointUniqueId) EditorGUILayout.ObjectField(
                        _spawnWaypoint[wave.Key], typeof(SpawnWaypointUniqueId), true, GUILayout.MaxWidth(300));

                    _spawnWaypoint[wave.Key] = spawnWaypoint;

                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Time appearance:", GUILayout.Width(200));
                    int timeAppearance = (int) EditorGUILayout.FloatField(
                        wave.Key.TimeAppearance, GUILayout.MaxWidth(300));
                    wave.Key.TimeAppearance = timeAppearance;
                    if (spawnWaypoint != null)
                    {
                        wave.Key.SpawnWaypointId = spawnWaypoint.Id;
                        SetGroupsEnemies(wave.Key);
                    }
                    EditorGUILayout.EndVertical();
                }
            }
            EditorGUILayout.EndVertical();
        }    
    }

    private void SetGroupsEnemies(WaveEnemies wave)
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        if (GUILayout.Button("Add new Group enemies"))
        {
            wave.AddGroup();
        }
        
        string headerGroups = "Groups enemies of wave";
        GUILayout.Label(headerGroups, EditorStyles.boldLabel);

        if (wave.GroupsEnemies.Count != 0)
        {
            for (int i = 0; i < wave.GroupsEnemies.Count; i++)
            {
                _staticDataService.LoadEnemies();
                GroupEnemies groupEnemies = wave.GroupsEnemies[i];
                if(_displayedGroupsEnemies.ContainsKey(groupEnemies) == false)
                    _displayedGroupsEnemies.Add(groupEnemies, true);

                string headerGroup = $"Group {i+1}";
                bool isDropdownGroup = _displayedGroupsEnemies[groupEnemies];
                isDropdownGroup = EditorGUILayout.Foldout(isDropdownGroup, headerGroup);
                _displayedGroupsEnemies[groupEnemies] = isDropdownGroup;

                if (isDropdownGroup)
                {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUILayout.BeginHorizontal();
                    if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20)))
                    {
                        _displayedGroupsEnemies.Remove(groupEnemies);
                        wave.DeleteGroup(groupEnemies);
                    }
                    GUILayout.Label(" - Delete wave", EditorStyles.boldLabel);
                    EditorGUILayout.EndHorizontal();
                    
                    EditorGUIUtility.labelWidth = 100;
                    EnemyTypeId typeId = (EnemyTypeId) EditorGUILayout.EnumPopup("Type enemy ", 
                        groupEnemies.TypeId,  GUILayout.MaxWidth(200));
                    EditorGUIUtility.labelWidth = 70;
                    groupEnemies.CountEnemyInGroup = EditorGUILayout.IntField("Count:", groupEnemies.CountEnemyInGroup, GUILayout.MaxWidth(150));
                    EditorGUIUtility.labelWidth = 150;
                    groupEnemies.TimeBetweenSpawnEnemy = EditorGUILayout.FloatField("Time Between Spawns:", groupEnemies.TimeBetweenSpawnEnemy, GUILayout.MaxWidth(200));
                    EditorGUIUtility.labelWidth = 150;
                    groupEnemies.WaitingBeforeSpawn = EditorGUILayout.FloatField("Waiting before spawn:", groupEnemies.TimeBetweenSpawnEnemy, GUILayout.MaxWidth(200));
                    groupEnemies.TypeId = typeId;
                    Rect position = GUILayoutUtility.GetLastRect();
                    position.x = 300;
                    position.y -= 60;
                    position.height = 80;
                    position.width = 80;


                    if (typeId != null)
                    {
                        Texture texturePrefab = _staticDataService.ForEnemies(typeId).Image.texture;
                        if (texturePrefab != null)
                        {
                            GUI.DrawTexture(position, texturePrefab, ScaleMode.StretchToFill);
                        }
                    }

                    EditorGUILayout.EndVertical();
                }
            }
        }
        EditorGUILayout.EndVertical();
    }

    private void DeleteAllGroupsOfWave(WaveEnemies wave)
    {
        List<GroupEnemies> groupsForDelete = new List<GroupEnemies>();
        foreach (var item in wave.GroupsEnemies)
        {
            if (_displayedGroupsEnemies.ContainsKey(item))
                groupsForDelete.Add(item);
        }

        foreach (var item in groupsForDelete)
        {
            _displayedGroupsEnemies.Remove(item);
        }
    }
    
    private void SetTowers()
    {
        EditorGUILayout.Space();
        string headerTowers = "Set permitted towers type";
        _isDropdownTower = EditorGUILayout.Foldout(_isDropdownTower, headerTowers);

        if (_isDropdownTower)
        {
            _staticDataService.LoadTowers();
            EditorGUILayout.BeginVertical("box");
            if (GUILayout.Button("Add tower"))
            {
                _towers.Add(TowerTypeId.None);
            }

            for (int i = 0; i < _towers.Count; i++)
            {
                TowerTypeId tower = _towers[i];
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.Height(20)))
                {
                    _towers.Remove(tower);
                }
                GUILayout.Label(" - Delete tower", EditorStyles.boldLabel);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();
                EditorGUIUtility.labelWidth = 100;
                TowerTypeId typeId = (TowerTypeId) EditorGUILayout.EnumPopup("Type tower ", 
                    tower,  GUILayout.MaxWidth(250));
                _towers[i] = typeId;
                Rect position = GUILayoutUtility.GetLastRect();
                position.x = 300;
                position.y -=35;
                position.height = 55;
                position.width = 55;
                
                if (typeId != null && typeId != TowerTypeId.None)
                {
                    Texture texturePrefab = _staticDataService.ForTowers(typeId).ImageForButton.texture;
                    GUI.DrawTexture(position, texturePrefab, ScaleMode.StretchToFill);
                }
                
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
        }
    }

    private void SetCountInitialCrystal()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("Set count initial crystal", EditorStyles.boldLabel);
        _countInitialCrystal = EditorGUILayout.IntField("Count crystals: ", _countInitialCrystal, GUILayout.MaxWidth(220));
        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();
    }
    
    private void SetTowerPlacePrice()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("Set tower place Price", EditorStyles.boldLabel);
        _towerPlacePrice = EditorGUILayout.IntField("Price: ", _towerPlacePrice, GUILayout.MaxWidth(220));
        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();
    }
    
    private void SetCrystalMinePrice()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("Set crystal raw mine Price", EditorStyles.boldLabel);
        _crystalMinePrice = EditorGUILayout.IntField("Price: ", _crystalMinePrice, GUILayout.MaxWidth(220));
        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();
    }
    
    private void SaveTheLevel()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if (GUILayout.Button("Save The level: " + _nameLevel + " ?"))
        {
            LevelStaticData levelStaticData = CreateInstance<LevelStaticData>();
            InitLevel(levelStaticData);
            string name = $"{_nameLevel}.asset";
            AssetDatabase.CreateAsset(levelStaticData, $"{AssetPath.CreateNewLevelPath}{name}");
            AssetDatabase.SaveAssets();
        }
    }

    private void InitLevel(LevelStaticData levelStaticData)
    {
        List<WaveEnemies> waves = new List<WaveEnemies>();
        foreach (var item in _displayedWavesEnemies.Keys)
        {
            waves.Add(item);
        }

        levelStaticData.WavesEnemies = waves;
        levelStaticData.Towers = _towers;
        levelStaticData.CountInitialCrystal = _countInitialCrystal;
        levelStaticData.TowerPlacePrice = _towerPlacePrice;
        levelStaticData.CrystalMinePrice = _crystalMinePrice;
        levelStaticData.SceneName = _scene.name;
    }
}
