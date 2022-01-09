using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFogCamera : MonoBehaviour
{

    [SerializeField] private bool doWeHaveFogInScene;

    private void Start()
    {
        doWeHaveFogInScene = RenderSettings.fog;
    }

    private void OnPreRender()
    {
        RenderSettings.fog = false;
    }
    private void OnPostRender()
    {
        RenderSettings.fog = false;
    }
}
