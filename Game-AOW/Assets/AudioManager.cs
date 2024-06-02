using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip background;
    public AudioClip pauseMenu;
    public AudioClip levelUp;
    public AudioClip deadMan;
    public AudioClip deadVilian;
    public AudioClip castleDown;
    public AudioClip knife;
    public AudioClip swordStroke;
    public AudioClip unitPlayer;
    public AudioClip power1;
    public AudioClip power2;
    public AudioClip power3;
    public AudioClip power4;
    public AudioClip power5;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        
        SFXSource.PlayOneShot(clip);

    }

}