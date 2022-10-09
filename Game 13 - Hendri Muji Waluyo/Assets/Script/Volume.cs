using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    
    [SerializeField] Slider slider_Master;
    [SerializeField] Slider slider_BGM;
    [SerializeField] Slider slider_SFX;
    [SerializeField] AudioSource hover;
    [SerializeField] AudioSource click;
    [SerializeField] AudioClip Hover_Sound;
    [SerializeField] AudioClip Click_Sound;
    [SerializeField] Toggle toggle;
    [SerializeField] AudioMixer mixer;


    void Start()
    {
        float db;

        mixer.GetFloat("Master_Vol", out db);
        slider_Master.value = (db+80)/80;

        mixer.GetFloat("BGM_Vol", out db);
        slider_BGM.value = (db+80)/80;

        mixer.GetFloat("SFX_Vol", out db);
        slider_SFX.value = (db+80)/80;
    }

    public void MasterVol(float value){
        value = value*80 - 80;
        mixer.SetFloat("Master_Vol", value);

        Debug.Log("Volume changed to "+ value);
    }

    public void BgmVol(float value){
        value = value*80 - 80;
        mixer.SetFloat("BGM_Vol", value);

        Debug.Log("BGM Volume changed to "+ value);
    }

    public void SfxVol(float value){
        value = value*80 - 80;
        mixer.SetFloat("SFX_Vol", value);

        Debug.Log("Volume SFX changed to "+ value);
    }

    public void Mute(bool value){
        if (value)
        {
            AudioListener.volume = 0;
            Debug.Log("Audio Off");
        }
        else
        {
            AudioListener.volume = 1;
            Debug.Log("Audio On");
        }
    }

    public void Hover(){
        hover.PlayOneShot(Hover_Sound);
    }

    public void Click(){
        click.PlayOneShot(Click_Sound);
    }
    
}
