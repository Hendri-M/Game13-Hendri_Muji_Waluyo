using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
    public void PlayGame()
    {
        LoadScenes.Game();
    }

    public void Settings()
    {
        LoadScenes.Load("Settings");
    }

    public void Back()
    {
        LoadScenes.Load("MainMenu");
    }
}
