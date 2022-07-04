using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndView : MonoBehaviour
{
    [SerializeField] private Button _menu;
    [SerializeField] private Button _return;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _spider;
    [SerializeField] private Image _hero;
    [SerializeField] private Image _win;
    [SerializeField] private Image _lose;

    public Button Menu => _menu;
    public Button Return => _return;

    public void SetText(string text) => _text.text = text;

    public void Activate() => gameObject.SetActive(true);
    public void DeActivate() => gameObject.SetActive(false);

    public void SetImageWin()
    {
        SetImageHero();
        _win.enabled = true;
        _lose.enabled = false;
    }

    public void SetImageLose()
    {
        SetImageSpider();
        _win.enabled = false;
        _lose.enabled = true;
    }

    private void SetImageHero()
    {
        _spider.enabled = false;
        _hero.enabled = true;
    }
    
    private void SetImageSpider()
    {
        _hero.enabled = false;
        _spider.enabled = true;
    }
}