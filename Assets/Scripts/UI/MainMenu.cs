using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_Crypt");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting!");
        Application.Quit();
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("Level_Crypt").buildIndex);
    }
   
}
