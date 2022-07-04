public interface IAudioPlayer : IService
{
    public void SetAudioSource(AudioSourceSound sound, AudioSourceMusic music);
    public void PlayClickButton();
    public void PlaySelectButton();
    public void PlayVictorySound();
    public void PlayLoseSound();
    public void PlaySoundSpending();
    public void PlaySoundError();
    public void PlaySoundHealth();
    public void PlayMusic();
    public void StopMusic();
    public void ChangeMusic();
    public void PlaySoundTouchPlace();
    public void PlaySoundTouchCrystalMine();
    public void PlaySoundAddWallet();
}