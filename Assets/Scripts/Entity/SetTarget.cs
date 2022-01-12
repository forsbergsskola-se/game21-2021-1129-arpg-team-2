using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    [SerializeField] private Vector3Value setTarget;

    private void OnMouseOver()
    {
        setTarget.Vector3 = this.transform.position;
    }

    private void OnMouseExit()
    {
        setTarget.Vector3 = new Vector3(0, 2000, 0);
    }
}
