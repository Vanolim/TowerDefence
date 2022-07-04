using System;

public interface IProduce
{
    public event Action<int> OnGiveCrystals;
    public event Action<IProduce> OnDestroyedProduce;
}