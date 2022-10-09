using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class SelectedAliasing : MonoBehaviour
{
    [SerializeField] GameObject[] selection;
    [SerializeField] int selected = 0;

    public void Next(){
        selection[selected].SetActive(false);
        selected = (selected + 1) % selection.Length;
        selection[selected].SetActive(true);

        Debug.Log("Anti-aliasing Next selected "+ selection[selected].tag);

    }

    public void Previous(){
        selection[selected].SetActive(false);
        selected--;
        if (selected < 0)
        {
            selected += selection.Length;
        }
        selection[selected].SetActive(true);

        Debug.Log("Anti-aliasing Previous selected "+ selection[selected].tag);
    }
}
