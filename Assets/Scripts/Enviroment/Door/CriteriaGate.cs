using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriteriaGate : MonoBehaviour {
    [Header("Spawn point indexes")]
    [Tooltip("Should be the same number as EnemySpawner spawn point element number")]
    [SerializeField] private int firstSpawnPointNumber;
    [SerializeField] private int lastSpawnPointNumber;

    [SerializeField] private int killCriteria;

    private int killCount;
    private bool isOpen;
    private Animator doorAnimator;
    public AudioSource gateOpeningSound;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        isOpen = false;
        doorAnimator = GetComponent<Animator>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.OnEnemyDeath += IndexCheck;
    }

    private void OnMouseDown()
    {
        if (isOpen)
        {
            doorAnimator.SetBool("isOpening", true);
            gateOpeningSound.Play();
        }
    }
    
    private void IndexCheck(int index)
    {
        Debug.Log("Rat with index " + index + " was killed");
        if (index >= firstSpawnPointNumber && index <= lastSpawnPointNumber) {
            Debug.Log($"Index of rat was between {firstSpawnPointNumber} and {lastSpawnPointNumber}");
            killCount++;
            
            if (killCount >= killCriteria)
            {
                isOpen = true;
            }
        }
    }
}
