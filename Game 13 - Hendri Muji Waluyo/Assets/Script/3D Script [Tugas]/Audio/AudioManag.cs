using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManag : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource source;
    [SerializeField] AudioSource jumpSFX;
    [SerializeField] AudioSource deathSFX;
    [SerializeField] AudioSource hoverSFX;
    [SerializeField] AudioSource clickSFX;
    [SerializeField] Slider volumeBGM;
    [SerializeField] Slider volume_SFX;
    [SerializeField] Toggle mute;

    float volume = 0f;
    
    private void Start() {
        float db;

        if (PlayerPrefs.GetInt("VolumeMute") == 1)
            mute.isOn = false;
        else
            mute.isOn = true;

        volume = PlayerPrefs.GetFloat("Volume");

        mixer.GetFloat("BGM_Vol", out db);
        volumeBGM.value = (db+80)/80;

        mixer.GetFloat("SFX_Vol", out db);
        volume_SFX.value = (db+80)/80;
    
    }

    public void BGM_Vol(float value)
    {
        value = value*80 - 80;
        mixer.SetFloat("BGM_Vol", value);

        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SFX_Vol(float value)
    {
        value = value*80 - 80;
        mixer.SetFloat("SFX_Vol", value);

        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void Muted(bool value)
    {
        if (value)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("VolumeMute", 0);
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("VolumeMute", 1);
        }
        
    }

    // SFX
    public void Jumped(){
        jumpSFX.Play();
    }

    public void Death(){
        deathSFX.Play();
    }

    public void Hover()
    {
        hoverSFX.Play();
    }

    public void Click()
    {
        clickSFX.Play();
    }
}
