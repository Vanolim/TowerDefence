using UnityEngine.UI;

public interface IHealthView
{
    public void Init(Slider sliderView, float maxHealth);
    public void UpdateView(float value);
    public void Deactivate();
}