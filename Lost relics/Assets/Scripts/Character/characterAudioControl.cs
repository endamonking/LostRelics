using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAudioControl : MonoBehaviour
{
    [Header("Audio clip")]
    public AudioClip[] attackSound;
    public AudioClip[] dodgeSound;
    public AudioClip[] hurtSound;

    private AudioSource audioSorce;
    // Start is called before the first frame update
    void Start()
    {
        audioSorce = GetComponent<AudioSource>();
        float audioVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        audioSorce.volume = audioVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAttackSound()
    {
        if (audioSorce == null || attackSound == null)
            return;

        audioSorce.PlayOneShot(attackSound[0]);

    }
    public void playHurtSound()
    {
        if (audioSorce == null || hurtSound == null)
            return;

        audioSorce.PlayOneShot(hurtSound[0]);

    }
    public void playDodgeSound()
    {
        if (audioSorce == null || dodgeSound == null)
            return;

        audioSorce.PlayOneShot(dodgeSound[0]);

    }
    //Will use when player press end turn and dont want the sound to overlap the other part
    public void stopAllCharacterSound()
    {
        audioSorce.Stop();
    }

}
