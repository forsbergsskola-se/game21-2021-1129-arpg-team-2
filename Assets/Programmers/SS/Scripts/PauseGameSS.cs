using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameSS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGameButton()
    {
        Time.timeScale = 0;
    }

    public void ContinueGameButton()
    {
        Time.timeScale = 1;
    }
}
