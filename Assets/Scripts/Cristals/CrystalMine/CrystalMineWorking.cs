using System;
using System.Collections;
using UnityEngine;

public class CrystalMineWorking : MonoBehaviour, IProduce, IPauseble
{
    [SerializeField] private float _miningTime;
    [SerializeField] private int _amountMining;

    private bool _isPause;
    
    public event Action<int> OnGiveCrystals;
    public event Action<IProduce> OnDestroyedProduce;

    private void Start() => StartCoroutine(Mine());

    private IEnumerator Mine()
    {
        WaitForSeconds time = new WaitForSeconds(_miningTime);

        while (true)
        {
            yield return time;
            if(_isPause == false)
                OnGiveCrystals?.Invoke(_amountMining);
        }
    }

    public void SetPause(bool isPaused) => _isPause = isPaused;
}