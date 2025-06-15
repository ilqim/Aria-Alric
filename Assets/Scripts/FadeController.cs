using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Start()
    {
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;
        fadeColor.a = 1f;
        fadeImage.color = fadeColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeColor.a = 0f;
        fadeImage.color = fadeColor;
        fadeImage.gameObject.SetActive(false);
    }
}
