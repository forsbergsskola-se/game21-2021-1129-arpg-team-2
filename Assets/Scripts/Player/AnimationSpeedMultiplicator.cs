using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSpeedMultiplicator : MonoBehaviour
{
    private Animator _animator;
    private float _defaultSpeed;
    [SerializeField] private CharStats playerStats;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _defaultSpeed = _animator.speed;
    }

    private void LateUpdate()
    {
        if (_animator.GetBool("Is attacking")) _animator.speed *= playerStats.AttackSpeed;
        else _animator.speed = _defaultSpeed;
    }
}
