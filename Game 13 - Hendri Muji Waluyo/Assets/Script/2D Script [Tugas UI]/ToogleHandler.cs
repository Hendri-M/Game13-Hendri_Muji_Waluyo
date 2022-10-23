using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleHandler : MonoBehaviour
{
    public void yes(){
        Debug.Log("Activate Vsync \"Yes\"");
    }
    public void no(){
        Debug.Log("Activate Vsync \"No\"");
    }


    public void Windowed(){
        Debug.Log("Screen mode Windowed is selected");
    }
    public void Fullscreen(){
        Debug.Log("Screen mode Fullscreen is selected");
    }
    public void Borderless(){
        Debug.Log("Screen mode Fullscreen Borderless is selected");
    }
}
