using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    public Text uiText;
    public string fullText;
    public float delay = 0.1f;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        if (textMeshProText != null)
        {
            textMeshProText.text = "";
            foreach (char letter in fullText.ToCharArray())
            {
                textMeshProText.text += letter;
                yield return new WaitForSeconds(delay);
            }
        }
        else if (uiText != null)
        {
            uiText.text = "";
            foreach (char letter in fullText.ToCharArray())
            {
                uiText.text += letter;
                yield return new WaitForSeconds(delay);
            }
        }
        else
        {
            Debug.LogWarning("Text component not assigned!");
        }
    }
}
