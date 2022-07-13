using UnityEngine;
using UnityEngine.UI;

public class HealthView : IHealthView
{
    private Slider _sliderView;
    private float _maxHealth;

    public void Init(Slider sliderView, float maxHealth)
    {
        _sliderView = sliderView;
        _maxHealth = maxHealth;
    }

    public void UpdateView(float value)
    {
        _sliderView.value = Mathf.InverseLerp(0, _maxHealth, value);
    }

    public void Deactivate()
    {
        _sliderView.gameObject.SetActive(false);
    }
}