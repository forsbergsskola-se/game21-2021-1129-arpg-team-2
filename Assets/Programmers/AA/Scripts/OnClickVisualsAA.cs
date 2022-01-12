using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnClickVisualsAA : MonoBehaviour
{
    public GameObject myPrefabValid;
    public GameObject myPrefabInvalid;
    public AudioSource ValidMove;
    public AudioSource InvalidMove;
    public AudioSource Hammer;
    public AudioSource Sword;
    public Transform prefabInitialPosition;
    private GameObject instantiatedValid;
    private GameObject instantiatedInvalid;

    //Add those lines
    private GameObject instantiatedPrefabValid;
    private GameObject instantiatedPrefabInvalid;

    //Add the whole Start() method
    private void Start()
    {
        instantiatedPrefabValid = Instantiate(myPrefabValid, Vector3.zero, Quaternion.identity);
        instantiatedPrefabValid.GetComponent<Animation>().Stop();
        instantiatedPrefabInvalid = Instantiate(myPrefabInvalid, Vector3.zero, Quaternion.identity);
        instantiatedPrefabInvalid.GetComponent<Animation>().Stop();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && CheckDestination(hit.transform.position) && !hit.transform.CompareTag("Destructible"))
            {
                //Added lines
                //Start
                instantiatedPrefabValid.transform.SetPositionAndRotation(hit.point, Quaternion.identity);
                instantiatedPrefabValid.GetComponent<Animation>().Stop();
                instantiatedPrefabValid.GetComponent<Animation>().Play();
                //End
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
                //Gate.Play();
            }
            else
            {
                //Added lines
                //Start
                instantiatedPrefabInvalid.transform.SetPositionAndRotation(hit.point, Quaternion.identity);
                instantiatedPrefabInvalid.GetComponent<Animation>().Stop();
                instantiatedPrefabInvalid.GetComponent<Animation>().Play();
                //End
                InvalidMove.Play();
            }
        }
    }
    private bool CheckDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas);
    }


}
