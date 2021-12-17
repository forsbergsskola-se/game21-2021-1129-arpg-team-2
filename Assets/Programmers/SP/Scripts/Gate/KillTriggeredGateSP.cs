using UnityEngine;

public class KillTriggeredGateSP : MonoBehaviour {
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private BooleanValue isLocked;
    
    public AudioSource gateOpening;
    private Animator doorAnimation;

    private int deathCount;
    private int initialEnemiesInRoom;
    
    private void Start()
    {
        doorAnimation = GetComponent<Animator>();
        enemySpawner.OnEnemyDeath += EnemyDied;
        initialEnemiesInRoom = enemySpawner.SpawnPointsCount;
        deathCount = 0;
        isLocked.BoolValue = true;
    }

    private void OnMouseDown()
    {
        if (!isLocked.BoolValue) 
        {
            Debug.Log("Gate be opening!");
            doorAnimation.SetBool("isOpening", true);
            gateOpening.Play();
        }
    }

    private void EnemyDied(int x)
    {
        deathCount++;
        if (deathCount >= initialEnemiesInRoom) isLocked.BoolValue = false;
    }
}