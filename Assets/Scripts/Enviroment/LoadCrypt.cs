    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.AI;
    using UnityEngine.SceneManagement;

public class LoadCrypt : MonoBehaviour
{
    [SerializeField] private BooleanValue comingFromForest;
    
    private void OnTriggerEnter(Collider other)
    {
        comingFromForest.BoolValue = true;
        FindObjectOfType<LoadingScene>().LoadScene("Level_Crypt");
        //SceneManager.LoadScene("Level_Crypt");
    }
}
