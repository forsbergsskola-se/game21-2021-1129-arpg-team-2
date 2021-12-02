using UnityEngine;
using UnityEngine.AI;

public class PlayernavMeshSP : MonoBehaviour
{
    [SerializeField] private Vector3Value playerPosition;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Vector3Value target;
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
                
                if (IsDestructable(target.Vector3) && !IsInRange(target.Vector3)) MoveTowardsWithRange(target.Vector3);
                else if (SetDestination(hit.transform.position)) MoveTowardsWithoutRange(hit, target.Vector3);
            }
        }

        playerPosition.Vector3 = transform.position;
    }

    private void MoveTowardsWithoutRange(RaycastHit hit, Vector3 target)
    {
        if (!IsDestructable(target))
        {
            Debug.Log("Free to go");
            navMeshAgent.destination = hit.point;
            navMeshAgent.stoppingDistance = 0;    
        }
    }

    private void MoveTowardsWithRange(Vector3 target)
    {
        Debug.Log("Moving towards a destructable stuff");
        navMeshAgent.destination = target;
        navMeshAgent.stoppingDistance = weapon.Range;
    }

    private static bool IsDestructable(Vector3 target) => target.y != 2000;

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

