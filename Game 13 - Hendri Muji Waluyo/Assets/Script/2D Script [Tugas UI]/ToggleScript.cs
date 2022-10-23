using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class ToggleGrup{
    public static Toggle getActive(this ToggleGroup group ){
        return group.ActiveToggles().FirstOrDefault();
    }
}
public class ToggleScript : MonoBehaviour
{
    public ToggleGroup Group_Vsync;
    public ToggleGroup Group_Screen;

    public void selectedVsync(){
        Toggle toggle = Group_Vsync.getActive();
        // Debug.Log("Vsync mode " + toggle.GetComponentInChildren<Text>().text);
    }
    public void selectedScreen(){
        Toggle toggle = Group_Screen.getActive();
        // Debug.Log("Screen mode " + toggle.GetComponentInChildren<Text>().text + " is selecte");
    }
}
