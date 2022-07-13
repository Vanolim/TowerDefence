using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private EnemyProduceView _enemyProduceView;
    [SerializeField] private Transform _canvas;

    private Camera _camera;
    private IHealthView _healthView;
    
    public EnemyProduceView EnemyProduceView => _enemyProduceView;
    public IHealthView Health => _healthView;

    public void Init(float maxHealth)
    {
        _camera = Camera.main;
        _healthView = new HealthView();
        _healthView.Init(_healthSlider, maxHealth);
    }

    private void LateUpdate()
    {
        _canvas.LookAt(transform.position + _camera.transform.forward);
    }
}