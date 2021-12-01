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
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && CheckDestination(hit.transform.position) && !hit.transform.GetComponent<EnemyFollowAA>())
            {
                Instantiate(myPrefabValid, hit.point, Quaternion.identity);
                ValidMove.Play();

            }
            else if (hit.transform.CompareTag("Wall") || hit.transform.GetComponent<EnemyFollowAA>())
            {
                InvalidMove.Play();
            }
            else
            {
                Instantiate(myPrefabInvalid, hit.point, Quaternion.identity);
                InvalidMove.Play();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && CheckDestination(hit.transform.position) && hit.transform.GetComponent<EnemyFollowAA>())
            {
                Sword.Play();
            }
            else if (hit.transform.CompareTag("Wall"))
            {
                Hammer.Play();
            }
        }
    }
    private bool CheckDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas);
    }

    
}
