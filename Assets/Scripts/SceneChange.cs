using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public string sceneName;
    public GameObject player1;
    public GameObject player2;
    public Image fadeImage;
    public Text fadeText;
    public float fadeDuration = 1f;
    public string textToShow = "Geçiş Yapılıyor...";

    private bool player1Inside = false;
    private bool player2Inside = false;
    private bool isTransitioning = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject == player1)
            {
                player1Inside = true;
                player1.SetActive(false);
            }

            if (other.gameObject == player2)
            {
                player2Inside = true;
                player2.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (player1Inside && player2Inside && !isTransitioning)
        {
            StartCoroutine(SceneTransition());
        }
    }

    public IEnumerator SceneTransition()
{
    fadeImage.gameObject.SetActive(true);
    fadeText.gameObject.SetActive(true);
    isTransitioning = true;
    yield return StartCoroutine(FadeOut());
    fadeText.text = textToShow;
    yield return StartCoroutine(ShowText());
    SceneManager.LoadScene(sceneName);
    yield return StartCoroutine(FadeIn());
    isTransitioning = false;
}


    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = fadeColor;
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            fadeImage.color = fadeColor;
            yield return null;
        }
    }

    private IEnumerator ShowText()
    {
        float elapsedTime = 0f;
        Color textColor = fadeText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeText.color = textColor;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textColor.a = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            fadeText.color = textColor;
            yield return null;
        }
    }

        public void StartSceneTransition()
    {
        if (!isTransitioning)
        {
            StartCoroutine(SceneTransition());
        }
    }

}
