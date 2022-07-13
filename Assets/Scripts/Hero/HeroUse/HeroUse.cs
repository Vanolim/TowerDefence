using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HeroUse : MonoBehaviour
{
    [SerializeField] private HeroUseEffect _heroUseEffect;
    [SerializeField] private float _radius;
    
    private SphereCollider _sphereCollider;

    public void Init()
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
        _sphereCollider.radius = _radius;
        _heroUseEffect.SetRadius(_radius);
    }
}