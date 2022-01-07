using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof_shadow : MonoBehaviour
{
    public GameObject roofShadow;
    public Animator fade;
    

    private void OnTriggerEnter(Collider dataFromTrigger)
    {
        if (dataFromTrigger.gameObject.name == "New Player")
        {
            fade.SetBool("Inside", true);
        }
    }
    private void OnTriggerExit(Collider dataFromTrigger)
    {
        if (dataFromTrigger.gameObject.name == "New Player")
        {
            fade.SetBool("Inside", false);
        }
    }
}
