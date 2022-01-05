using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);
        }
    }
}
