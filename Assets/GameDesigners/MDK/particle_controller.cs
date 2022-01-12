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
    public bool secArcaneEffect;
    public bool secBallsEffect;

    //finding all particles attached to weapon
    public GameObject greenGlow;
    public GameObject redGlow;
    public GameObject blueGlow;
    public GameObject yellowGlow;
    public GameObject ribbonEffect;
    public GameObject fireEffect;
    public GameObject eyesEffect;
    public GameObject primaryChainsEffect;
    public GameObject secondaryArcaneEffect;
    public GameObject secondaryBallsEffect;

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
       
        if (ribbEffect)
        {
            ribbonEffect.SetActive(true);
        }
        else if (primChainEffect)
        {
            primaryChainsEffect.SetActive(true);
        }
        else if (burnEffect)
        {
            fireEffect.SetActive(true);
        }
        else
        {
            primaryChainsEffect.SetActive(false);
            ribbonEffect.SetActive(false);
            fireEffect.SetActive(false);
        }
        if (eyeEffect)
        {
            eyesEffect.SetActive(true);
        }
        else if (secArcaneEffect)
        {
            secondaryArcaneEffect.SetActive(true);
        }
        else if (secBallsEffect)
        {
            secondaryBallsEffect.SetActive(true);
        }
        else
        {
            eyesEffect.SetActive(false);
            secondaryArcaneEffect.SetActive(false);
            secondaryBallsEffect.SetActive(false);
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
            particleColorArcane(greenGrad);
            particleColorBalls(greenGrad);

        }
        else if (rGlow)
        {
            redGlow.SetActive(true);
            particleColorRibbons(redGrad);
            particleColorFire(redGrad);
            particleColorEyes(redGrad);           
            particleColorChainsPrimary(redGrad);
            particleColorArcane(redGrad);
            particleColorBalls(redGrad);
        }
        else if (bGlow)
        {
            blueGlow.SetActive(true);
            particleColorRibbons(blueGrad);
            particleColorFire(blueGrad);
            particleColorEyes(blueGrad);           
            particleColorChainsPrimary(blueGrad);
            particleColorArcane(blueGrad);
            particleColorBalls(blueGrad);
        }
        else if (yGlow)
        {
            yellowGlow.SetActive(true);
            particleColorRibbons(yellowGrad);
            particleColorFire(yellowGrad);
            particleColorEyes(yellowGrad);         
            particleColorChainsPrimary(yellowGrad);
            particleColorArcane(yellowGrad);
            particleColorBalls(yellowGrad);
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
            particleColorArcane(whiteGrad);
            particleColorBalls(whiteGrad);
        }
    }


    //actually setting my gradients
    void setColors()
    {
        greenGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.green, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f), new GradientAlphaKey(1.0f, 0.9f), new GradientAlphaKey(0.0f, 1.0f) });
        redGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f), new GradientAlphaKey(1.0f, 0.9f), new GradientAlphaKey(0.0f, 1.0f) });
        blueGrad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.cyan, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f), new GradientAlphaKey(1.0f, 0.9f), new GradientAlphaKey(0.0f, 1.0f) });
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

    void particleColorBalls(Gradient ballsGrad)
    {
        ParticleSystem Balls = secondaryBallsEffect.GetComponent<ParticleSystem>();
        var colorBalls = Balls.colorOverLifetime;
        colorBalls.color = ballsGrad;
    }

    void particleColorChainsPrimary(Gradient primaryChainsGrad)
    {
        GameObject Chain1 = primaryChainsEffect.transform.Find("Chain 1").gameObject;
        GameObject Chain2 = primaryChainsEffect.transform.Find("Chain 2").gameObject;
        GameObject Chain3 = primaryChainsEffect.transform.Find("Chain 3").gameObject;
        ParticleSystem psChain1 = Chain1.GetComponent<ParticleSystem>();
        ParticleSystem psChain2 = Chain2.GetComponent<ParticleSystem>();
        ParticleSystem psChain3 = Chain3.GetComponent<ParticleSystem>();
        var colorChain1 = psChain1.colorOverLifetime;
        var colorChain2 = psChain2.colorOverLifetime;
        var colorChain3 = psChain3.colorOverLifetime;
        colorChain1.color = primaryChainsGrad;
        colorChain2.color = primaryChainsGrad;
        colorChain3.color = primaryChainsGrad;
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
