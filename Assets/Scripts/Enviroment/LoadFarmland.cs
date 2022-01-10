using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFarmland : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LoadingScene>().LoadScene("Farmland_NEW_MAIN");
        //SceneManager.LoadScene("Farmland_NEW_MAIN");
    }
}
