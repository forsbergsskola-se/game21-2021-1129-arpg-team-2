using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    void Update()
    {
        Invoke("FadeFin", 5f);
    }

    private void FadeFin()
    {
        gameObject.SetActive(false);
    }

}
