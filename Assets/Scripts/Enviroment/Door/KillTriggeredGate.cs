using UnityEngine;

public class KillTriggeredGate : MonoBehaviour {
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private BooleanValue isLocked;
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
        if (!isLocked.BoolValue) {
            Debug.Log("Gate be opening!");
            doorAnimation.SetBool("isOpening", true);
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
}