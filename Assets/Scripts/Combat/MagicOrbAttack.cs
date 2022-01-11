using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MagicOrbAttack : MonoBehaviour {
    [SerializeField] private MagicOrb magicOrbPrefab;
    [SerializeField] private GameObject orbSpawnPosition;
    [SerializeField] private float orbLerpTime = 0.4f;
    private GameObject player;
    private MagicOrb createdOrb;
    private AudioSource orbAttack;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        orbAttack = GetComponent<AudioSource>();
    }

    private void CreateOrb()
    {
         createdOrb = Instantiate(magicOrbPrefab, orbSpawnPosition.transform.position, quaternion.identity, orbSpawnPosition.transform);
         createdOrb.SetUp(gameObject);
         createdOrb.transform.localScale = new Vector3(0.25f,0.25f,0.25f);
    }

    private void LaunchOrb()
    {
        StartCoroutine(MoveOrbToTarget());
        orbAttack.Play();
    }
    
    private IEnumerator MoveOrbToTarget()
    {
        float progress = 0;
        while (progress < 1 && createdOrb != null)
        {
            progress += Time.deltaTime / orbLerpTime;
            createdOrb.transform.position =
                Vector3.Lerp(orbSpawnPosition.transform.position, player.transform.position, progress);
            yield return 0;
        }
    }
}
