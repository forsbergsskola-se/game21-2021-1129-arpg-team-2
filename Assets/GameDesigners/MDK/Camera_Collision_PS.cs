using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Collision_PS : MonoBehaviour
{
    ParticleSystem ps;
    Gradient alphaGrad = new();
    Gradient alphaGradDef = new();
    private void Start()
    {
        StartCoroutine(gradientFIX());
        ps = GetComponent<ParticleSystem>();
    }
    private void OnParticleCollision(GameObject other)
    {
        alphaGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.1f), new GradientAlphaKey(0.33f, 0.3f), new GradientAlphaKey(0.33f, 0.7f), new GradientAlphaKey(0.0f, 0.9f) });
        ps = GetComponent<ParticleSystem>();
        var colorPs = ps.colorOverLifetime;
        colorPs.color = alphaGrad;
    }
    IEnumerator gradientFIX()
    {
        hey:
        ps = GetComponent<ParticleSystem>();
        alphaGradDef.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.1f), new GradientAlphaKey(1f, 0.3f), new GradientAlphaKey(1f, 0.7f), new GradientAlphaKey(0.0f, 0.9f) });
        var colorPs = ps.colorOverLifetime;
        colorPs.color = alphaGradDef;
     
        yield return new WaitForSeconds(10);

        goto hey;
    }

}
