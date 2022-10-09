using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown selected_Quality;
    [SerializeField] TMP_Dropdown selected_Resolution;

    public void SelectedQuality(int value){
        Debug.Log("Quality " + selected_Quality.options[value].text + " is selected");
    }
    
    public void SelectedResolution(int value){
        Debug.Log("Resolution " + selected_Resolution.options[value].text + " is selected.");
    }
}
