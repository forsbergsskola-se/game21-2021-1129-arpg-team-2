using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_controller : MonoBehaviour
{
    //bools to determine if effect is on or not
    public bool gGlow;
    public bool rGlow;
    public bool bGlow;
    public bool yGlow;
    public bool ribbEffect;
    public bool burnEffect;
    public bool eyeEffect;
    public bool primChainEffect;
    public bool secChainEffect;
    public bool secArcaneEffect;

    //finding all particles attached to weapon
    public GameObject greenGlow;
    public GameObject redGlow;
    public GameObject blueGlow;
    public GameObject yellowGlow;
    public GameObject ribbonEffect;
    public GameObject fireEffect;
    public GameObject eyesEffect;
    public GameObject primaryChainsEffect;
    public GameObject secondaryChainsEffect;
    public GameObject secondaryArcaneEffect;

    //creating gradients for color, setting these gradients later
    Gradient greenGrad = new();
    Gradient redGrad = new();
    Gradient blueGrad = new();
    Gradient yellowGrad = new();
    Gradient whiteGrad = new();


  


    void Update()
    {
        //sets gradients
        setColors();

        //deciding what secondary and primary effects are active
        if (secArcaneEffect)
        {
            secondaryArcaneEffect.SetActive(true);
        }
        else
        {
            secondaryArcaneEffect.SetActive(false);
        }
        if (ribbEffect)
        {
            ribbonEffect.SetActive(true);
        }
        else
        {
            ribbonEffect.SetActive(false);
        }
        if (burnEffect)
        {
            fireEffect.SetActive(true);
        }
        else
        {
            fireEffect.SetActive(false);
        }
        if (eyeEffect)
        {
            eyesEffect.SetActive(true);
        }
        else
        {
            eyesEffect.SetActive(false);
        }
        if (primChainEffect)
        {
            primaryChainsEffect.SetActive(true);
        }
        else
        {
            primaryChainsEffect.SetActive(false);
        }
        if (secChainEffect)
        {
            secondaryChainsEffect.SetActive(true);
        }
        else
        {
            secondaryChainsEffect.SetActive(false);
        }

        //deciding which glow is active
        if (gGlow)
        {
            greenGlow.SetActive(true);
            //changing color gradient of particles according to glow
            particleColorRibbons(greenGrad);
            particleColorFire(greenGrad);
            particleColorEyes(greenGrad);
            particleColorChainsPrimary(greenGrad);
            particleColorChainsSecondary(greenGrad);
            particleColorArcane(greenGrad);

        }
        else if (rGlow)
        {
            redGlow.SetActive(true);
            particleColorRibbons(redGrad);
            particleColorFire(redGrad);
            particleColorEyes(redGrad);
            particleColorChainsPrimary(redGrad);
            particleColorChainsSecondary(redGrad);
            particleColorArcane(redGrad);
        }
        else if (bGlow)
        {
            blueGlow.SetActive(true);
            particleColorRibbons(blueGrad);
            particleColorFire(blueGrad);
            particleColorEyes(blueGrad);
            particleColorChainsPrimary(blueGrad);
            particleColorChainsSecondary(blueGrad);
            particleColorArcane(blueGrad);
        }
        else if (yGlow)
        {
            yellowGlow.SetActive(true);
            particleColorRibbons(yellowGrad);
            particleColorFire(yellowGrad);
            particleColorEyes(yellowGrad);
            particleColorChainsPrimary(yellowGrad);
            particleColorChainsSecondary(yellowGrad);
            particleColorArcane(yellowGrad);
        }
        else
        {
            greenGlow.SetActive(false);
            redGlow.SetActive(false); 
            blueGlow.SetActive(false);
            yellowGlow.SetActive(false);
            //if no glows are active particles will be white
            particleColorRibbons(whiteGrad);
            particleColorFire(whiteGrad);
            particleColorEyes(whiteGrad);
            particleColorChainsPrimary(whiteGrad);
            particleColorChainsSecondary(whiteGrad);
            particleColorArcane(whiteGrad);
        }
    }


    //actually setting my gradients
    void setColors()
    {
        greenGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.green, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f), new GradientAlphaKey(1.0f, 0.9f), new GradientAlphaKey(0.0f, 1.0f) });
        redGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f), new GradientAlphaKey(1.0f, 0.9f), new GradientAlphaKey(0.0f, 1.0f) });
        blueGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.blue, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f), new GradientAlphaKey(1.0f, 0.9f), new GradientAlphaKey(0.0f, 1.0f) });
        yellowGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f), new GradientColorKey(Color.yellow, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f), new GradientAlphaKey(1.0f, 0.9f), new GradientAlphaKey(0.0f, 1.0f) });
        whiteGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f), new GradientAlphaKey(1.0f, 0.9f), new GradientAlphaKey(0.0f, 1.0f) });
    }



    //lets us decide color of the particles
    void particleColorEyes(Gradient eyesGrad)
    {
        //accessing the particle system in gameobject
        ParticleSystem eyes = eyesEffect.GetComponent<ParticleSystem>();
        //creating a color over lifetime variable
        var colorEyes = eyes.colorOverLifetime;
        //storing gradient in color over lifetime variable
        colorEyes.color = eyesGrad;
    }

    void particleColorRibbons(Gradient ribbGrad)
    {
        ParticleSystem ribbon = ribbonEffect.GetComponent<ParticleSystem>();
        var colorRibb = ribbon.colorOverLifetime;
        colorRibb.color = ribbGrad;
    }

    // same as before but this time we are changing the children aswell
    void particleColorFire(Gradient fireGrad)
    {
        //finds the children of the fire effect
        GameObject fireEffectAdd = fireEffect.transform.Find("Primary fire add").gameObject;
        GameObject fireEffectSmoke = fireEffect.transform.Find("Primary fire smoke").gameObject;
        //repeating earlier process once for each particle we want to change color of
        ParticleSystem fire = fireEffect.GetComponent<ParticleSystem>();
        ParticleSystem fireAdd = fireEffectAdd.GetComponent<ParticleSystem>();
        ParticleSystem fireSmoke = fireEffectSmoke.GetComponent<ParticleSystem>();
        var colorFire = fire.colorOverLifetime;
        var colorFireAdd = fireAdd.colorOverLifetime;
        var colorFireSmoke = fireSmoke.colorOverLifetime;
        colorFire.color = fireGrad;
        colorFireAdd.color = fireGrad;
        colorFireSmoke.color = fireGrad;
    }

    void particleColorChainsPrimary(Gradient primaryChainsGrad)
    {
        GameObject Chains1 = primaryChainsEffect.transform.Find("Chains 1").gameObject;
        GameObject Chains2 = primaryChainsEffect.transform.Find("Chains 2").gameObject;
        GameObject Chains3 = primaryChainsEffect.transform.Find("Chains 3").gameObject;
        GameObject Chains4 = primaryChainsEffect.transform.Find("Chains 4").gameObject;
        GameObject Chains5 = primaryChainsEffect.transform.Find("Chains 5").gameObject;
        GameObject Chains6 = primaryChainsEffect.transform.Find("Chains 6").gameObject;
        ParticleSystem psChains1 = Chains1.GetComponent<ParticleSystem>();
        ParticleSystem psChains2 = Chains2.GetComponent<ParticleSystem>();
        ParticleSystem psChains3 = Chains3.GetComponent<ParticleSystem>();
        ParticleSystem psChains4 = Chains4.GetComponent<ParticleSystem>();
        ParticleSystem psChains5 = Chains5.GetComponent<ParticleSystem>();
        ParticleSystem psChains6 = Chains6.GetComponent<ParticleSystem>();
        var colorChains1 = psChains1.colorOverLifetime;
        var colorChains2 = psChains2.colorOverLifetime;
        var colorChains3 = psChains3.colorOverLifetime;
        var colorChains4 = psChains4.colorOverLifetime;
        var colorChains5 = psChains5.colorOverLifetime;
        var colorChains6 = psChains6.colorOverLifetime;
        colorChains1.color = primaryChainsGrad;
        colorChains2.color = primaryChainsGrad;
        colorChains3.color = primaryChainsGrad;
        colorChains4.color = primaryChainsGrad;
        colorChains5.color = primaryChainsGrad;
        colorChains6.color = primaryChainsGrad;

    }

    void particleColorChainsSecondary(Gradient secondaryChainsGrad)
    {
        GameObject Chain1 = secondaryChainsEffect.transform.Find("Chain 1").gameObject;
        GameObject Chain2 = secondaryChainsEffect.transform.Find("Chain 2").gameObject;
        GameObject Chain3 = secondaryChainsEffect.transform.Find("Chain 3").gameObject;
        ParticleSystem psChain1 = Chain1.GetComponent<ParticleSystem>();
        ParticleSystem psChain2 = Chain2.GetComponent<ParticleSystem>();
        ParticleSystem psChain3 = Chain3.GetComponent<ParticleSystem>();
        var colorChain1 = psChain1.colorOverLifetime;
        var colorChain2 = psChain2.colorOverLifetime;
        var colorChain3 = psChain3.colorOverLifetime;
        colorChain1.color = secondaryChainsGrad;
        colorChain2.color = secondaryChainsGrad;
        colorChain3.color = secondaryChainsGrad;
    }

    void particleColorArcane(Gradient arcaneGrad)
    {
        GameObject sphereEffect = secondaryArcaneEffect.transform.Find("sphere effect").gameObject;
        ParticleSystem arcane = secondaryArcaneEffect.GetComponent<ParticleSystem>();
        ParticleSystem sphere = sphereEffect.GetComponent<ParticleSystem>();
        var colorArcane = arcane.colorOverLifetime;
        var colorSphere = sphere.colorOverLifetime;
        colorArcane.color = arcaneGrad;
        colorSphere.color = arcaneGrad;
    }
}
