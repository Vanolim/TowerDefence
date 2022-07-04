using UnityEngine;

public class AudioPlayer : IAudioPlayer
{
    private readonly SoundCollection _soundCollection;
    private AudioSource _sound;
    private AudioSource _music;
    public AudioPlayer(SoundCollection soundCollection)
    {
        _soundCollection = soundCollection;
    }

    public void SetAudioSource(AudioSourceSound sound, AudioSourceMusic music)
    {
        _sound = sound.AudioSource;
        _music = music.AudioSource;
    }

    public void PlayClickButton()
    {
        _sound.clip = _soundCollection.Button;
        _sound.Play();
    }

    public void PlaySelectButton()
    {
        _sound.clip = _soundCollection.ButtonSelect;
        _sound.Play();
    }

    public void PlayVictorySound()
    {
        _sound.clip = _soundCollection.Victory;
        _sound.Play();
    }

    public void PlayLoseSound()
    {
        _sound.clip = _soundCollection.Lose;
        _sound.Play();
    }

    public void PlaySoundSpending()
    {
        _sound.clip = _soundCollection.SoundSpending;
        _sound.Play();
    }

    public void PlaySoundError()
    {
        _sound.clip = _soundCollection.SoundError;
        _sound.Play();
    }

    public void PlaySoundHealth()
    {
        _sound.clip = _soundCollection.SoundHealth;
        _sound.Play();
    }

    public void PlaySoundTouchPlace()
    {
        _sound.clip = _soundCollection.TouchPlace;
        _sound.Play();
    }

    public void PlaySoundTouchCrystalMine()
    {
        _sound.clip = _soundCollection.TouchCrystalMine;
        _sound.Play();
    }

    public void PlaySoundAddWallet()
    {
        _sound.clip = _soundCollection.AddWallet;
        _sound.Play();
    }

    public void PlayMusic() => _music.Play();

    public void StopMusic() => _music.Stop();
    public void ChangeMusic()
    {
        _music.clip = _soundCollection.GetRandomMusic();
        _music.Play();
    }
}