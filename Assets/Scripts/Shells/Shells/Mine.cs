using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Shell
{
    [SerializeField] private float _searchSphereRadius;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private ParticleSystem _core;
    [SerializeField] private ParticleSystem _smoke;
    [SerializeField] private AudioSource _sound;
    
    private float _age;
    private bool _isReachedGround = false;
    
    public override bool GameUpdate()
    {
        if (_isReachedGround == false)
        {
            _age += Time.deltaTime;
            MoveAlongPath();
            Rotate(_age);
            
            if (CheckingReachedGround())
            {
                _isReachedGround = true;
                List<Enemy> hurtEnemies = FindNearbyEnemies(_searchSphereRadius);
                if (hurtEnemies.Count != 0)
                {
                    ToDamage(hurtEnemies);
                }

                _meshRenderer.enabled = false;
                StartCoroutine(PlayRecycle());
                return false;
            }
            return true;
        }

        return false;
    }

    private void MoveAlongPath()
    {
        Vector3 nextPosition = LaunchPoint + LaunchVelocity * _age;
        nextPosition.y -= 0.5f * 9.81f * _age * _age;
        transform.localPosition = nextPosition;
    }

    private IEnumerator PlayRecycle()
    {
        _core.Play();
        _smoke.Play();
        _sound.Play();
        yield return new WaitForSeconds(1f);
        Recycle();
    }
}
