using UnityEngine;

public class GoodsZoneUseParticle : MonoBehaviour
{
   [SerializeField] private ParticleSystem _particleSystem;

   public ParticleSystem ParticleSystem => _particleSystem;
}
