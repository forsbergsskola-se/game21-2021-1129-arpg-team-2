using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnClickVisualsAA : MonoBehaviour
{
    //Animator anim;
    public GameObject myPrefabValid;
    public GameObject myPrefabInvalid;
    public AudioSource ValidMove;
    public AudioSource InvalidMove;
    public AudioSource Hammer;

    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //anim.SetTrigger("Active");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && CheckDestination(hit.transform.position))
            {
                Instantiate(myPrefabValid, hit.point, Quaternion.identity);
                ValidMove.Play();

            }
            else if (hit.transform.tag == "Wall")
            {
                Hammer.Play();
            }
            else if (hit.transform.tag == "Enemy")
            {
                Hammer.Play();
            }
            else
            {
                Instantiate(myPrefabInvalid, hit.point, Quaternion.identity);
                InvalidMove.Play();
            }
            
        }
        
        
    }
    private bool CheckDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas))
        {
            return true;
        }
        return false;
    }

    
}
