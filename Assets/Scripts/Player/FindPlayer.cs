using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    [SerializeField] private GameObjectValue player;

    private void Awake()
    {
        player.Value = GameObject.FindGameObjectWithTag("Player");
    }
}
