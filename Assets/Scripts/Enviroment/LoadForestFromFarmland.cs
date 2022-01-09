using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadForestFromFarmland : MonoBehaviour
{
    [SerializeField] private BooleanValue comingFromFarm;
    
    private void OnTriggerEnter(Collider other)
    {
        comingFromFarm.BoolValue = true;
        SceneManager.LoadScene("ForestNew");
    }
}
