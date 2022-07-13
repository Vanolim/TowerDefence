using System;
using System.Collections;
using UnityEngine;

public class CrystalMineWorking : MonoBehaviour, IProduce, IPauseble
{
    [SerializeField] private float _miningTime;
    [SerializeField] private int _amountMining;

    private bool _isPaused;
    
    public event Action<int> OnGiveCrystals;
    public event Action<IProduce> OnDestroyedProduce;

    private void Start() => StartCoroutine(Mine());

    private IEnumerator Mine()
    {
        WaitForSeconds time = new WaitForSeconds(_miningTime);

        while (true)
        {
            yield return time;
            if(_isPaused == false)
                OnGiveCrystals?.Invoke(_amountMining);
        }
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;

    public void Destroyed()
    {
        OnDestroyedProduce?.Invoke(this);
        Destroy(this);
    }
}