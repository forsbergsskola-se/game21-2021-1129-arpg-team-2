using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public TMP_Text loadingPercent;
    public Slider loadingBar;
    public CanvasGroup loadingBarCanvasGroup;
    void Update()
    {
        // Press the space key to start coroutine
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Use a coroutine to load the Scene in the background
            StartCoroutine(LoadAsyncScene("MainScene"));
        }
    }

    public void LoadScene(string sceneName)
    {

        StartCoroutine(LoadAsyncScene(sceneName));
    }

    IEnumerator LoadAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        loadingBarCanvasGroup.alpha = 1;
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            loadingPercent.text = asyncLoad.progress*100 + " %";
            loadingBar.value = asyncLoad.progress;
            
            yield return null;
        }

    }
}
