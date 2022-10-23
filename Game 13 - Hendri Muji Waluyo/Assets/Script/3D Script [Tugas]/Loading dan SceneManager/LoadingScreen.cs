using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMPro.TMP_Text load;
     
     private void Start()
     {
        StartCoroutine(Loading());   
     }

    IEnumerator Loading()
    {
        image.fillAmount = 0;
        yield return new WaitForSeconds(3);

        var async = SceneManager.LoadSceneAsync(LoadScenes.SceneLoader1);

        while (async.isDone == false)
        {
            image.fillAmount = async.progress;
            load.text = "Loading. . . \t" + async.progress*100 + "%";
            yield return null;
        }
    }
}
