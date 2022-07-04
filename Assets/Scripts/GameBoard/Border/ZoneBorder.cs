using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ZoneBorder : MonoBehaviour
{
    public event Action OnEnter;
    public event Action OnExit;
    
    private void OnTriggerEnter(Collider other)
    {
        OnEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit.Invoke();
    }
}
