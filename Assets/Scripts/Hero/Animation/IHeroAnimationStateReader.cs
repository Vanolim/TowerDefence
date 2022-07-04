public interface IHeroAnimationStateReader
{
    public void EnteredState(int stateHash);
    public void ExitState(int stateHash);
    
    public HeroAnimatorState State { get; }
}