using UnityEngine;

public class GateDoor : MonoBehaviour {
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
        if (!isLocked)
        {
            doorAnimation.SetBool("isOpening", true);
        }
    }

    private void EnemyDied(int deathCount)
    {
        if (deathCount >= initialEnemiesInRoom)
        {
            isLocked = false;
        }
    }
}
