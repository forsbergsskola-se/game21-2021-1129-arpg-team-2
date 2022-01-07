using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem healEffect;

    public void PlayEffect() => StartCoroutine(nameof(VisualHealEffect));
    
    private IEnumerator VisualHealEffect()
    {
        var healParticles = Instantiate(healEffect, transform.position, quaternion.identity);
        healParticles.Play();
        yield return new WaitForSeconds(.3f);
    }
}
