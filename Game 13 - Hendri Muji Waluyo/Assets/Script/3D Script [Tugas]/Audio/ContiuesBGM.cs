using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContiuesBGM : MonoBehaviour
{
    private void Awake() {
        GameObject [] bgmSound = GameObject.FindGameObjectsWithTag("BGMSound");
        
        if (bgmSound.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
