using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Slider master;
    [SerializeField]
    private Slider music, effect;
    [Header("Audio Group")]
    [SerializeField] 
    private AudioMixer audioMixer;
    [SerializeField]
    private AudioMixerGroup MasterG,MusicG,EffectG;

    private void Start()
    {
        music.value = PlayerPrefs.GetFloat("MusicV", 1.0f);
        master.value = PlayerPrefs.GetFloat("MasterV", 1.0f);
        effect.value = PlayerPrefs.GetFloat("EffectV", 1.0f);
        this.gameObject.SetActive(false);


    }
    private void Update()
    {
        
    }
    public void AdjustMusicVolume()
    {
        float volume = music.value;
        if (volume <= 0)
            audioMixer.SetFloat(MusicG.name, -80.0f);
        else
            audioMixer.SetFloat(MusicG.name, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicV", volume);
    }
    public void AdjustMasterVolume()
    {
        float volume = master.value;
        if (volume <= 0)
            audioMixer.SetFloat(MasterG.name, -80.0f);
        else
            audioMixer.SetFloat(MasterG.name, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterV", volume);
    }
    public void AdjustEffectVolume()
    {
        float volume = effect.value;
        if (volume <= 0)
            audioMixer.SetFloat(EffectG.name, -80.0f);
        else
            audioMixer.SetFloat(EffectG.name, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("EffectV", volume);
    }

    public void openOption()
    {
        this.gameObject.SetActive(true);
    }
    public void back()
    {
        this.gameObject.SetActive(false);
    }

}
