using System.Collections;
using UnityEngine;

public class Foo : MonoBehaviour {

    void OnEnable() {
        // Start a Coroutine
        StartCoroutine(EnemyRoutine());
    }
    
    // Coroutine - Asynchronous Programming // compiled as a State Machine
    IEnumerator EnemyRoutine() {

        // Begin Idling
        while (!CanSeePlayer()) {
            Sit();
            // Continue after next Update
            yield return null;
        }
        
        // This enemy is Slow, he needs a moment to realize, what he's seeing
        yield return new WaitForSeconds(1f);
        
        // Be Alert
        while (!IsDead()) {
            if (CanSeePlayer()) {
                AttackPlayer();
                yield return null;
            } else {
                // Nested Coroutine
                yield return Patrol();
            }
        }

        Despawn();
    }

    IEnumerator Patrol() {
        // walk to a
        // stand for 2 seconds
        // walk to b
        // look around
        // walk to c
        // sit down
        // wait 1 second
        // stand up
        // walk to a
        yield return null;
    }

    bool IsDead() {
        return false;
    }

    bool CanSeePlayer() {
        return false;
    }

    void AttackPlayer() {
        
    }

    void Sit() {
        
    }
    
    void WalkAround() {
        
    }

    void Despawn() {
        
    }
}