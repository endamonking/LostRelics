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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAttackSound()
    {
        if (audioSorce == null || attackSound == null)
            return;

        audioSorce.clip = attackSound[0];
        audioSorce.Play();

    }
    public void playHurtSound()
    {
        if (audioSorce == null || hurtSound == null)
            return;

        audioSorce.clip = hurtSound[0];
        audioSorce.Play();

    }
    public void playDodgeSound()
    {
        if (audioSorce == null || dodgeSound == null)
            return;

        audioSorce.clip = dodgeSound[0];
        audioSorce.Play();

    }
    //Will use when player press end turn and dont want the sound to overlap the other part
    public void stopAllCharacterSound()
    {
        audioSorce.Stop();
    }

}
