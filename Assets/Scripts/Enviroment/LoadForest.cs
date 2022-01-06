using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadForest : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SceneManager.LoadScene(2);
        }
    }
}
