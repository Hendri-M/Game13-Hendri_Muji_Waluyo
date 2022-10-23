using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Source;
    [SerializeField] AudioSource hover;
    [SerializeField] AudioSource click;
    [SerializeField] AudioClip Hover_Sound;
    [SerializeField] AudioClip Click_Sound;
    [SerializeField] AudioMixer mixer;

    public void Hover(){
        hover.PlayOneShot(Hover_Sound);
    }

    public void Click(){
        click.PlayOneShot(Click_Sound);
    }

}
