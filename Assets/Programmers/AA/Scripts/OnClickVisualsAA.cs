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
    
    private void Start()
    {
        
        instantiatedValid = Instantiate(myPrefabValid, prefabInitialPosition.position, myPrefabValid.transform.rotation);
        instantiatedInvalid = Instantiate(myPrefabInvalid, prefabInitialPosition.position, myPrefabInvalid.transform.rotation);
        prefabInitialPosition.position = Vector3.zero;
        prefabInitialPosition.rotation = instantiatedValid.transform.rotation;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && CheckDestination(hit.transform.position) && !hit.transform.GetComponent<EnemyFollowAA>())
            {
                //Instantiate(myPrefabValid, hit.point, Quaternion.identity);
                ValidMove.Play();
                instantiatedValid.transform.SetPositionAndRotation(hit.point, prefabInitialPosition.rotation);
                instantiatedValid.GetComponent<Animation>().Play();

            }
            else if (hit.transform.CompareTag("Wall") )
            {
                Hammer.Play();
            }
            else if (hit.transform.GetComponent<EnemyFollowAA>() )
            {
                Sword.Play();
            }
            else if (hit.transform.CompareTag("Gate"))
            {
                Hammer.Play();
            }
            else
            {
                //Instantiate(myPrefabInvalid, hit.point, Quaternion.identity);
                InvalidMove.Play();
                instantiatedInvalid.transform.SetPositionAndRotation(hit.point, prefabInitialPosition.rotation);
                instantiatedInvalid.GetComponent<Animation>().Play();
            }
        }
    }
    private bool CheckDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas);
    }

    
}
