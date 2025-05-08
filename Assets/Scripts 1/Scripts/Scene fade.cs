using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenefade : MonoBehaviour
{
    public Image sceneFade;

    private void Awake()
    {
        sceneFade = GetComponent<Image>();
    }

    public IEnumerator FadeInCoroutine(float duration)
    {
        Color startColor = new Color(sceneFade.color.r, sceneFade.color.g, sceneFade.color.b, 1);
        Color targetColor = new Color(sceneFade.color.r, sceneFade.color.g, sceneFade.color.b, 0);

        yield return FadeCoroutine(startColor, targetColor, duration);

        gameObject.SetActive(false);
    }

    public IEnumerator FadeOutCoroutine(float duration)
    {
        Color startColor = new Color(sceneFade.color.r, sceneFade.color.g, sceneFade.color.b, 0);
        Color targetColor = new Color(sceneFade.color.r, sceneFade.color.g, sceneFade.color.b, 1);

        gameObject.SetActive(true);

        yield return FadeCoroutine (startColor, targetColor, duration);
    }

    private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
    {
        float elapsedTime = 0;
        float elapsedPercentage = 0;

        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / duration;
            sceneFade.color = Color.Lerp(startColor, targetColor, elapsedPercentage);

            yield return null;
            elapsedTime += Time.deltaTime;
        }
    }
}
