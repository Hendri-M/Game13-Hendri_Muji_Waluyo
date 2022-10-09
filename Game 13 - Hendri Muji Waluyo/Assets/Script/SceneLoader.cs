using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void sceneManage(){
        SceneManager.LoadScene(1);

        Debug.Log("Scene berpindah ke Scene Settings.");
    }

    public void SceneBack(){
        SceneManager.LoadScene(0);

        Debug.Log("Scene kembali ke Scene Main Menu.");
    }
}
