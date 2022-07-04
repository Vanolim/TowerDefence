using System;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private EnemyHealthView _enemyHealthView;
    [SerializeField] private EnemyProduceView _enemyProduceView;
    [SerializeField] private Transform _canvas;

    private Camera _camera;

    public EnemyHealthView EnemyHealthView => _enemyHealthView;
    public EnemyProduceView EnemyProduceView => _enemyProduceView;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        _canvas.LookAt(transform.position + _camera.transform.forward);
    }
}