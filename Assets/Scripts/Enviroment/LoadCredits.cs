using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene("Credits");
        FindObjectOfType<LoadingScene>().LoadScene("Credits");
    }
}
