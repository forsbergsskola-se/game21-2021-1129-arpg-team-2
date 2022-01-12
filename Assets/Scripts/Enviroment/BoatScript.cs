using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public GameObject cam2;
    private Animator boAnimator;
    private static readonly int BoatSailing = Animator.StringToHash("BoatSailing");
    private RaycastHit hit;
    private GameObject player;

    private void Awake()
    {
        boAnimator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnMouseDown()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100) && hit.transform.CompareTag("Boat"))
        {
            player.SetActive(false);
            boAnimator.SetBool(BoatSailing, true);
            Camera.main.enabled = false;
            cam2.SetActive(true);
        }
        
    }
}
