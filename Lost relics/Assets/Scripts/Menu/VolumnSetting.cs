using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumnSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    void Start()
    {
        musicSlider.onValueChanged.AddListener(delegate { AdjustMusicVolume(); });
        AdjustMusicVolume();


    }
   
    private  void AdjustMusicVolume() {
       
        float volume = musicSlider.value;
        Debug.Log(musicSlider.value);
        audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }
}
