using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MagicOrbAttack : MonoBehaviour {
    [SerializeField] private GameObject magicOrbPrefab;
    [SerializeField] private GameObject orbSpawnPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private float orbLerpTime = 0.4f;
    private GameObject createdOrb;


    private void CreateOrb() {
         createdOrb = Instantiate(magicOrbPrefab, orbSpawnPosition.transform.position, quaternion.identity, orbSpawnPosition.transform);
    }

    private IEnumerator MoveOrbToTarget() {
        float progress = 0;
        while (progress < orbLerpTime) {
            progress += Time.deltaTime;
            createdOrb.transform.position =
                Vector3.Lerp(createdOrb.transform.position, player.transform.position, progress);
            yield return 0;
        }
    }

    private void LaunchOrb() {
        StartCoroutine(MoveOrbToTarget());
    }
}
