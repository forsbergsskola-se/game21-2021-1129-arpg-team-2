using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnClickVisualsAA : MonoBehaviour
{
    //Animator anim;
    public GameObject myPrefab;

    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //anim.SetTrigger("Active");
            //Instantiate(myPrefab, hit.position, Quaternion.identity);
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(myPrefab, hit.point, Quaternion.identity);

            }
            
        }
        
        
    }

    
}
