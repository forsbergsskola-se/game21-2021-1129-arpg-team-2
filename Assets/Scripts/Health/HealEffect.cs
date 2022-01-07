using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem healEffect;

    public void PlayEffect() => healEffect.Play();
}
