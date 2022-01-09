using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayernavMesh : MonoBehaviour
{
    
    [SerializeField] private Vector3Value playerPosition;
    [SerializeField] private Vector3Value playerStartPosition;
    [SerializeField] private Weapon weapon;
    [SerializeField] private GameObjectValue movementTarget;
    [SerializeField] private FloatValue stopFrontOfGateDistance;
    [SerializeField] private BooleanValue attackOnGoing;
    [SerializeField] private GameEvent attackStop;
    [SerializeField] private BooleanValue fromForestToCrypt;
    [SerializeField] private Vector3Value cryptFinalPosition;
    [SerializeField] private BooleanValue fromFarmToForest;
    [SerializeField] private Vector3Value forestFinalPosition;
    private NavMeshAgent navMeshAgent;
    private RaycastHit hit;
    Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerPosition.Vector3 = transform.position;
        movementTarget.Value = null;
    }

    private void Start()
    {
        playerStartPosition.Vector3 = transform.position;
        animator = GetComponentInChildren<Animator>();

        if (fromForestToCrypt.BoolValue)
        {
            navMeshAgent.Warp(cryptFinalPosition.Vector3);
            fromForestToCrypt.BoolValue = false;
        }

        if (fromFarmToForest.BoolValue)
        {
            navMeshAgent.Warp(forestFinalPosition.Vector3);
            fromFarmToForest.BoolValue = false;
        }
        
        
    }

    private void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            attackOnGoing.BoolValue = false;
            attackStop.Raise();
            movementTarget.Value = null;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                
                if (hit.transform.CompareTag("Outside") || hit.transform.CompareTag("Wall") ||  hit.transform.CompareTag("Water"))
                {
                    navMeshAgent.isStopped = true;
                }
                else if (hit.transform.CompareTag("Destructible") || hit.transform.CompareTag("Enemy"))
                {
                    navMeshAgent.isStopped = false;
                    var position = hit.transform.position;
                    navMeshAgent.destination = position;
                    navMeshAgent.stoppingDistance = weapon.Range;
                    movementTarget.Value = hit.transform.gameObject;
                    
                    RotateTowards(position);
                }
                else if (hit.transform.CompareTag("Gate"))
                {
                    navMeshAgent.isStopped = false;
                    var position = hit.transform.position;
                    navMeshAgent.destination = position;
                    navMeshAgent.stoppingDistance = stopFrontOfGateDistance.InitialValue;
                    movementTarget.Value = hit.transform.gameObject;
                    
                    RotateTowards(position);
                }
                else if (SetDestination(hit.transform.position))
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.destination = hit.point;
                    navMeshAgent.stoppingDistance = 1;
                    movementTarget.Value = null;
                    
                    RotateTowards(hit.point);
                }
                else
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.destination = hit.point;
                    navMeshAgent.stoppingDistance = 1;
                    movementTarget.Value = null;
                    
                    RotateTowards(hit.point);
                }
            }
        }
        
        playerPosition.Vector3 = transform.position;
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

    private void RotateTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * navMeshAgent.acceleration);
    } 

    public void ResetToStartPosition()
    {
        navMeshAgent.Warp(playerStartPosition.Vector3);
    }
}