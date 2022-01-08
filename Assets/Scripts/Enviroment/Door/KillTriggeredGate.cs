using UnityEngine;

public class KillTriggeredGate : MonoBehaviour {
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private FloatValue minDistanceToOpen;
    [SerializeField] private Vector3Value playerPosition;
    
    public AudioSource gateOpening;
    private Animator doorAnimation;
    private int initialEnemiesInRoom;
    private bool gateIsLocked;
    public bool GateIsLocked => gateIsLocked;
    
    private void Start()
    {
        // Get the animator from parent component if it's a door that rotates on its pivot
        if (!TryGetComponent(out doorAnimation)) doorAnimation = GetComponentInParent<Animator>();
        enemySpawner.OnEnemyDeath += EnemyDied;
        initialEnemiesInRoom = enemySpawner.SpawnPointsCount;
        gateIsLocked = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("Gate is being clicked!");
        if (!gateIsLocked)
        {
            doorAnimation.SetBool("isOpening", true);
            gateOpening.Play();
        }
    }

    private void EnemyDied(int deathCount)
    {
        if (deathCount >= initialEnemiesInRoom) gateIsLocked = false;
    }
}