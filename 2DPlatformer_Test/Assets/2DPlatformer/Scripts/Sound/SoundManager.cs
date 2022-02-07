using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    
    private AudioSource _audiosource;

    [Header("SoundForPlayer")]
    public AudioClip _attack;
    public AudioClip _ratlaunch;
    public AudioClip _heal;
    public AudioClip _death;
    public AudioClip _jump;
    public AudioClip _takingDamage;
    public AudioClip _landing;
    public AudioClip _dash;
    public AudioClip _walk;

    [Header("Sound for Ennemies")]
    public AudioClip _attackofennemies;
    public AudioClip _deathOfEnnemies;
    public AudioClip _ennemiesTakingDamage;
    public AudioClip _playerSpotted;
    public AudioClip _walkOfEnnemies;

    [Header("Sound for Menu")]
    public AudioClip _cantSelect;
    public AudioClip _selectOption;
    public AudioClip _MenuTheme;

    [Header("Sound for Corpses")]
    public AudioClip _interactwithCorpse;

    private void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audio)
    {
        _audiosource.PlayOneShot(audio);
    }
}