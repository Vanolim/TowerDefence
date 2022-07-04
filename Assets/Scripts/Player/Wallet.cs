using System;
using System.Collections.Generic;

public class Wallet : IDisposable
{
    private int _currentBalance;
    private readonly IAudioPlayer _audioPlayer;
    private readonly List<IProduce> _produces = new List<IProduce>();
    
    public event Action<int> OnChanged;

    public int CurrentBalance
    {
        get => _currentBalance;
        private set
        {
            _currentBalance = value;
            OnChanged?.Invoke(_currentBalance);
        }
    }
    public Wallet(int initialBalance, IAudioPlayer audioPlayer)
    {
        CurrentBalance = initialBalance;
        _audioPlayer = audioPlayer;
    }

    public bool TryBuy(int price)
    {
        if (price <= CurrentBalance)
        {
            PlaySoundSpending();
            Remove(price);
            return true;
        }

        PlaySoundError();
        return false;
    }
    
    private void Add(int value) => CurrentBalance += value;
    private void Remove(int value) => CurrentBalance -= value;
    
    public void AddProduce(IProduce produce)
    {
        produce.OnGiveCrystals += Add;
        produce.OnDestroyedProduce += RemoveProduce;
        _produces.Add(produce);
    }

    private void RemoveProduce(IProduce produce)
    {
        produce.OnGiveCrystals -= Add;
        produce.OnDestroyedProduce -= RemoveProduce;
        _produces.Remove(produce);
    }

    public void Dispose()
    {
        foreach (var produce in _produces)
        {
            produce.OnGiveCrystals -= Add;
            produce.OnDestroyedProduce -= RemoveProduce;
        }
    }

    private void PlaySoundSpending() => _audioPlayer.PlaySoundSpending();
    private void PlaySoundError() => _audioPlayer.PlaySoundError();
}
