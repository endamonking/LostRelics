using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip Menu;
     
    private void Start()
    {
        musicSource.clip = Menu;
        musicSource.Play();
   
    }

    public void SFX(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();

    }
}
