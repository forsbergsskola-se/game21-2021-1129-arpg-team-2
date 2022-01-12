using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class OnClickVisuals : MonoBehaviour
{
    public GameObject myPrefabValid;
    public GameObject myPrefabInvalid;
    public AudioSource ValidMove;
    public AudioSource InvalidMove;
    public AudioSource Hammer;
    public AudioSource Sword;
    public AudioSource Gate;
    //Add those lines
    private GameObject instantiatedPrefabValid;
    private GameObject instantiatedPrefabInvalid;
    private Vector3 offset;

    //Add the whole Start() method
    private void Start()
    {
        instantiatedPrefabValid = Instantiate(myPrefabValid, Vector3.zero, Quaternion.identity);
        instantiatedPrefabValid.GetComponentInChildren<Animation>().Stop();
        instantiatedPrefabInvalid = Instantiate(myPrefabInvalid, Vector3.zero, Quaternion.identity);
        instantiatedPrefabInvalid.GetComponentInChildren<Animation>().Stop();

        offset = new Vector3(0, .2f, 0);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            NavMeshHit navMeshHit;
            
            if (NavMesh.SamplePosition(hit.point, out navMeshHit, 1f, NavMesh.AllAreas) && NavMesh.GetAreaFromName("Walkable") == 0 && !hit.transform.CompareTag("Destructible") && !hit.transform.CompareTag("Enemy") && !hit.transform.CompareTag("UI"))
            {
                instantiatedPrefabValid.transform.SetPositionAndRotation(hit.point+offset, Quaternion.identity);
                instantiatedPrefabValid.GetComponentInChildren<Animation>().Stop();
                instantiatedPrefabValid.GetComponentInChildren<Animation>().Play();
                
                ValidMove.Play();
            }
            else if (hit.transform.CompareTag("Player"))
            {
                
            }
            else if (hit.transform.CompareTag("Ground") && !hit.transform.CompareTag("Destructible") && !hit.transform.CompareTag("Enemy") && !hit.transform.CompareTag("UI"))
            {
                instantiatedPrefabValid.transform.SetPositionAndRotation(hit.point+offset, Quaternion.identity);
                instantiatedPrefabValid.GetComponentInChildren<Animation>().Stop();
                instantiatedPrefabValid.GetComponentInChildren<Animation>().Play();
                
                ValidMove.Play();
            }
            else if (hit.transform.CompareTag("Destructible"))
            {
                Hammer.Play();
            }
            else if (hit.transform.CompareTag("Enemy"))
            {
                Sword.Play();
            }
            else if (hit.transform.CompareTag("Gate"))
            {
                Gate.Play();
            }
            else if (hit.transform.CompareTag("Outside") || hit.transform.CompareTag("Wall"))
            {
                instantiatedPrefabInvalid.transform.SetPositionAndRotation(hit.point, Quaternion.identity);
                instantiatedPrefabInvalid.GetComponentInChildren<Animation>().Stop();
                instantiatedPrefabInvalid.GetComponentInChildren<Animation>().Play();
                    
                InvalidMove.Play();
            }
            else
            {
                if (!hit.transform.CompareTag("UI"))
                {
                    instantiatedPrefabInvalid.transform.SetPositionAndRotation(hit.point, Quaternion.identity);
                    instantiatedPrefabInvalid.GetComponentInChildren<Animation>().Stop();
                    instantiatedPrefabInvalid.GetComponentInChildren<Animation>().Play();
                    
                    InvalidMove.Play();
                }
                
            }
        }
    }
}
