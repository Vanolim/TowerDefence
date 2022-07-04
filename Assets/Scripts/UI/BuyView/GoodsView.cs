using System;
using UnityEngine;

public abstract class GoodsView : MonoBehaviour, IGoodsView
{
    [SerializeField] private Transform _placeForSpawn;
    [SerializeField] private GoodsZoneUseParticle _particle;

    public event Action OnNotActive;
    
    private bool _isFree = true;
    private bool _isActive;
    public bool IsFree => _isFree;
    public bool IsActive => _isActive;
    public Transform GetTransformObject() => gameObject.transform;
    public Transform GetTransformForSpawn() => _placeForSpawn;
    public void SetIsNotFree()
    {
        Deactivate();
        _isFree = false;
    }

    public void Activate()
    {
        _isActive = true;
        if(_isFree == false)
             return;
        _particle.ParticleSystem.Play();
    }

    public void Deactivate()
    {
        OnNotActive?.Invoke();
        _isActive = false;
        if(_isFree == false)
            return;
        _particle.ParticleSystem.Stop();
    }
}