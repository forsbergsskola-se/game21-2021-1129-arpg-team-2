using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DarkenScreen : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    private Image imageBlack;

    private void Awake()
    {
        imageBlack = GetComponentInChildren<Image>();
    }

    public void OnPlayerDefeated()
    {
        StartCoroutine(FadeInBlack());
    }

    public void OnPlayerNotDefeated()
    {
        StartCoroutine(FadeInBlack(false));
    }

    private IEnumerator FadeInBlack(bool fadeToBlack = true)
    {
        var imgColor = imageBlack.color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (imageBlack.color.a < 1)
            {
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
