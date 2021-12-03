using UnityEngine;

public class KillTriggeredGate : MonoBehaviour {
    [SerializeField] private EnemySpawner enemySpawner;
    private Animator doorAnimation;
    private bool isLocked = true;
    private int initialEnemiesInRoom;
    private void Start()
    {
        doorAnimation = GetComponent<Animator>();
        enemySpawner.OnEnemyDeath += EnemyDied;
        initialEnemiesInRoom = enemySpawner.SpawnPointsCount;
    }

    private void OnMouseDown()
    {
        if (!isLocked) {
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
            isLocked = false;
        }
    }
}