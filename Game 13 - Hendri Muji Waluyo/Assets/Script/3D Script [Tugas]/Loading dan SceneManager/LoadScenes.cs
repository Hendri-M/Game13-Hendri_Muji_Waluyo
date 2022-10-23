using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadScenes
{
    private static string SceneLoader;

    public static string SceneLoader1 { get => SceneLoader; }

    public static void Load(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void Game()
    {
        ProgressLoad("GamePlay");
    }

    public static void ProgressLoad(string name)
    {
        SceneLoader = name;
        SceneManager.LoadScene("LoadingScreen");
    }

    public static void Replay()
    {
        var sceneActiveNow = SceneManager.GetActiveScene().name;
        ProgressLoad(sceneActiveNow);
    }
}
