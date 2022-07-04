using TMPro;
using UnityEngine;

public class EnemyProduceView : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;
    public void Activate(float countCrystal)
    {
        SetText(countCrystal);
        gameObject.SetActive(true);
    }

    private void SetText(float countCrystal)
    {
        _tmpText.text = $"+ {countCrystal}";
    }
}