using System.Collections.Generic;
using UnityEngine;

public class SoundCollection : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonSelect;
    [SerializeField] private AudioClip _button;
    [SerializeField] private AudioClip _victory;
    [SerializeField] private AudioClip _lose;
    [SerializeField] private AudioClip _touchPlace;
    [SerializeField] private AudioClip _touchCrystalMine;
    [SerializeField] private AudioClip _soundError;
    [SerializeField] private AudioClip _soundSpending;
    [SerializeField] private AudioClip _soundHealth;
    [SerializeField] private AudioClip _addWallet;
    [SerializeField] private List<AudioClip> _musics = new List<AudioClip>();

    public AudioClip ButtonSelect => _buttonSelect;
    public AudioClip Button => _button;
    public AudioClip Victory => _victory;
    public AudioClip Lose => _lose;
    public AudioClip TouchPlace => _touchPlace;
    public AudioClip TouchCrystalMine => _touchCrystalMine;
    public AudioClip SoundError => _soundError;
    public AudioClip SoundSpending => _soundSpending;
    public AudioClip SoundHealth => _soundHealth;
    public AudioClip AddWallet => _addWallet;

    public AudioClip GetRandomMusic() => _musics[Random.Range(0, _musics.Count)];
}