using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class OnClickVisualsFarmland : MonoBehaviour
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
    private RaycastHit hit;

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

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100) && !hit.transform.CompareTag("UI"))
            {

                if (hit.transform.CompareTag("Destructible"))
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
                else if (hit.transform.CompareTag("Outside") || hit.transform.CompareTag("Wall") || hit.transform.CompareTag("Water"))
                {
                    instantiatedPrefabInvalid.transform.SetPositionAndRotation(hit.point, Quaternion.identity);
                    instantiatedPrefabInvalid.GetComponentInChildren<Animation>().Stop();
                    instantiatedPrefabInvalid.GetComponentInChildren<Animation>().Play();
                    
                    InvalidMove.Play();
                }
                else if (SetDestination(hit.point) || hit.transform.CompareTag("Ground"))
                {
                    instantiatedPrefabValid.transform.SetPositionAndRotation(hit.point+offset, Quaternion.identity);
                    instantiatedPrefabValid.GetComponentInChildren<Animation>().Stop();
                    instantiatedPrefabValid.GetComponentInChildren<Animation>().Play();
                
                    ValidMove.Play();
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
    private bool SetDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas))
        {
            return true;
        }
        return false;
    }
}
