using UnityEngine;
using UnityEngine.AI;

public class PlayernavMesh : MonoBehaviour
{
    [SerializeField] private Vector3Value playerPosition;
    [SerializeField] private Weapon weapon;
    public Vector3Value entityDestination;
    private NavMeshAgent navMeshAgent;
    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerPosition.Vector3 = transform.position;
    }

    private void Update()
    {
        //navMeshAgent.destination = movePositionTransform.position;
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                entityDestination.Vector3 = hit.transform.position;
                
                if (IsDestructable(hit) && !IsInRange(entityDestination.Vector3)) MoveTowardsWithRange(hit);
                else if (SetDestination(hit.transform.position)) MoveTowardsWithoutRange(hit);
            }
        }

        playerPosition.Vector3 = transform.position;
    }

    private void MoveTowardsWithoutRange(RaycastHit hit)
    {
        navMeshAgent.destination = hit.point;
        navMeshAgent.stoppingDistance = 0;
    }

    private void MoveTowardsWithRange(RaycastHit hit)
    {
        Debug.Log("Moving towards a destructable stuff");
        navMeshAgent.destination = hit.transform.position;
        navMeshAgent.stoppingDistance = weapon.Range;
    }

    private static bool IsDestructable(RaycastHit hit) => 
        hit.transform.GetComponent<Destructible>() != null;

    private bool IsInRange(Vector3 target)
    {
        return Vector3.Distance(transform.position, target) <= weapon.Range;
    }

    private bool SetDestination(Vector3 targetDestination)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
            return true;
        }
        return false;
    }

    public void TestTest()
    {
        navMeshAgent.SetDestination(entityDestination.Vector3);
    }
}

