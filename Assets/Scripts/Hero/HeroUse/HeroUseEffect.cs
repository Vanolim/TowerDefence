using UnityEngine;

public class HeroUseEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _circle;
    [SerializeField] private ParticleSystem _ring;

    private const float MAGNIFACTION_FACTOR_CIRCLE = 1.25f;
    private const float MAGNIFACTION_FACTOR_RING = 2f;

    public void SetRadius(float value)
    {
        _circle.startSize = value * MAGNIFACTION_FACTOR_CIRCLE;
        _ring.startSize = value * MAGNIFACTION_FACTOR_RING;
    }
}