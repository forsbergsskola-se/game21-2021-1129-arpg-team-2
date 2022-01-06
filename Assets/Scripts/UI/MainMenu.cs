using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject scroll;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject graphicsMenu;
    
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
            if (scroll.gameObject.activeSelf)
            {
                scroll.gameObject.SetActive(false);
                inGameMenu.gameObject.SetActive(false);
                audioMenu.gameObject.SetActive(false);
                graphicsMenu.gameObject.SetActive(false);
                optionsMenu.gameObject.SetActive(false);
                
                UnpauseGame();
            }
            else
            {
                scroll.gameObject.SetActive(true);
                inGameMenu.gameObject.SetActive(true);
                
                PauseGame();
            }
        }
    }
}
