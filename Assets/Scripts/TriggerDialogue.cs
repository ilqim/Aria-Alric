using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialogue : MonoBehaviour
{
    public Image speechBubblePrefab;
    public string dialogueText;
    private TextMeshProUGUI dialogueTextComponent;
    private Transform playerTransform;
    public Canvas canvas;

    private void Start()
    {
        if (speechBubblePrefab != null)
        {
            dialogueTextComponent = speechBubblePrefab.GetComponentInChildren<TextMeshProUGUI>();
            if (dialogueTextComponent == null)
            {
                Debug.LogError("Konuşma balonunda TextMeshProUGUI bileşeni bulunamadı!");
            }

            speechBubblePrefab.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Konuşma balonu referansı atanmadı!");
        }
    }

    private void Update()
    {
        if (speechBubblePrefab.gameObject.activeSelf && playerTransform != null)
        {
            Vector3 worldPos = playerTransform.position;
            Vector3 localPos = canvas.transform.InverseTransformPoint(worldPos);

            localPos.y += 170;

            speechBubblePrefab.rectTransform.localPosition = localPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!speechBubblePrefab.gameObject.activeSelf)
            {
                speechBubblePrefab.gameObject.SetActive(true);
            }

            if (dialogueTextComponent != null)
            {
                dialogueTextComponent.text = dialogueText;
            }

            playerTransform = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            speechBubblePrefab.gameObject.SetActive(false);
            playerTransform = null;
        }
    }
}
