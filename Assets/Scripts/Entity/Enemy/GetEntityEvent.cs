using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEntityEvent : MonoBehaviour
{
    [SerializeField] private GameEventListener listner;
    [SerializeField] private EntityAttack entityAttack;
    
    private void Awake()
    {
        listner.Event = entityAttack.IsAttacking;
    }
}
