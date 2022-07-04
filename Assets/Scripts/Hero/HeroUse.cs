using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HeroUse : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private ParticleSystem _circle;
    [SerializeField] private ParticleSystem _ring;

    private SphereCollider _sphereCollider;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        SetRadius();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IGoodsView goodView)) 
            goodView.Activate();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IGoodsView goodView))
            goodView.Deactivate();
    }

    private void SetRadius()
    {
        float magnificationFactorCircle = 1.25f;
        float magnificationFactorRing = 2f;
        
        _sphereCollider.radius = _radius;
        _circle.startSize = _radius * magnificationFactorCircle;
        _ring.startSize = _radius * magnificationFactorRing;
    }
    
}