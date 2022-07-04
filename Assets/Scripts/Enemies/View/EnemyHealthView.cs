using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private EnemyHealth _enemyHealth;
    private float _maxHealth;

    public void Init(EnemyHealth enemyHealth, float maxHealth)
    {
        _enemyHealth = enemyHealth;
        _maxHealth = maxHealth;

        _enemyHealth.OnHealthChanged += UpdateView;
        _enemyHealth.OnHealthOver += Unsubscribe;
    }

    private void UpdateView(float value)
    {
        _slider.value = Mathf.InverseLerp(0, _maxHealth, value);
    }

    private void Unsubscribe()
    {
        _enemyHealth.OnHealthChanged -= UpdateView;
        _enemyHealth.OnHealthOver -= Unsubscribe;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}