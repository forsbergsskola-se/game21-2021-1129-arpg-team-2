using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour {
    private void Start() {
        //StartCoroutine(Lifetime());
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Col");
        Destroy(this.gameObject);
    }

    private IEnumerator Lifetime() {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}