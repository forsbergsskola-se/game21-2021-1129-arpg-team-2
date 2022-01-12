using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadForest : MonoBehaviour
{
    [SerializeField] private GameObject loadingSceneCanvas;
    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LoadingScene>().LoadScene("ForestNew");
        //SceneManager.LoadScene("ForestNew");
    }
}
