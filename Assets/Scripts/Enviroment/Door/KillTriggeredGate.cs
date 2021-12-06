using UnityEngine;

public class KillTriggeredGate : MonoBehaviour {
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private BooleanValue isLocked;
    [SerializeField] private FloatValue minDistanceToOpen;
    [SerializeField] private Vector3Value playerPosition;
    public AudioSource gateOpening;
    private Animator doorAnimation;
    // private BooleanValue isLocked;
    private int initialEnemiesInRoom;
    private void Start()
    {
        doorAnimation = GetComponent<Animator>();
        enemySpawner.OnEnemyDeath += EnemyDied;
        initialEnemiesInRoom = enemySpawner.SpawnPointsCount;
        isLocked.BoolValue = true;
    }

    private void OnMouseDown()
    {
        if (!isLocked.BoolValue && DistanceDoorCheck()) 
        {
            Debug.Log("Gate be opening!");
            doorAnimation.SetBool("isOpening", true);
            gateOpening.Play();

        }
    }

    private void EnemyDied(int deathCount)
    {
        Debug.Log("deathCount: " + deathCount);
        Debug.Log("initialEnemiesInRoom: " + initialEnemiesInRoom);
        
        if (deathCount >= initialEnemiesInRoom)
        {
            isLocked.BoolValue = false;
        }
    }

    private bool DistanceDoorCheck()
    {
        return Mathf.Round(Vector3.Distance(transform.position, playerPosition.Vector3)) <=
               minDistanceToOpen.InitialValue;
    }
}