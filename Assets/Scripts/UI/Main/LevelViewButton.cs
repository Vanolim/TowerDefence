using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelViewButton : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private GameObject _passed;
    [SerializeField] private TMP_Text _nameLevel;
    [SerializeField] private Image _sceneImage;

    public Button Play => _play;

    public void Init(string nameScene, Sprite image, bool isPassed)
    {
        _nameLevel.text = nameScene;
        _sceneImage.sprite = image;
        
        if(isPassed)
            _passed.SetActive(true);
        else
            _passed.SetActive(false);
    }
}
