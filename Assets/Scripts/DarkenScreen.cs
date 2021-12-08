using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DarkenScreen : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    private Image imageBlack;

    public void OnPlayerDefeated()
    {
        imageBlack = GetComponentInChildren<Image>();
        StartCoroutine(FadeInBlack());
    }

    private IEnumerator FadeInBlack(bool fadeToBlack = true)
    {
        var imgColor = imageBlack.color;
        float fadeAmount;

        if (fadeToBlack)
        {
            Debug.Log("Inside fadeToBlack, image color alpha: " + imageBlack.color.a);
            while (imageBlack.color.a < 1)
            {
                Debug.Log("fading to black coroutine firing");
                fadeAmount = imgColor.a + (fadeSpeed * Time.deltaTime);
                imgColor = new Color(imgColor.r, imgColor.g, imgColor.b, fadeAmount);
                imageBlack.color = imgColor;
                yield return null;
            }
        }
        else
        {
            while (imageBlack.color.a > 0)
            {
                fadeAmount = imgColor.a - (fadeSpeed * Time.deltaTime);
                imgColor = new Color(imgColor.r, imgColor.g, imgColor.b, fadeAmount);
                imageBlack.color = imgColor;
                yield return null;
            }
        }
        yield return new WaitForEndOfFrame();
    }
}
