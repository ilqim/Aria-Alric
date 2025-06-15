using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText1;
    public TextMeshProUGUI dialogueText2;

    public TextMeshProUGUI dialogueText3;

    public GameObject Balloon;

    void Start()
    {
        if (Balloon != null)
        {
            dialogueText1 = Balloon.GetComponentInChildren<TextMeshProUGUI>();

            if (dialogueText1 != null)
            {
                Debug.Log("TextMeshProUGUI bulundu");
            }
            else
            {
                Debug.LogWarning("Balloon içinde TextMeshProUGUI bulunamadı!");
            }
        }
        else
        {
            Debug.LogWarning("Balloon GameObject atanmadı!");
        }
    }

    public void SetDialogueText(string newText)
    {
        if (dialogueText1 != null)
        {
            dialogueText1.text = newText;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI bulunamadı veya atanmadı!");
        }
    } public void SetDialogueText1(string newText)
    {
        if (dialogueText2 != null)
        {
            dialogueText2.text = newText;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI bulunamadı veya atanmadı!");
        }
    }

    public void SetDialogueText2(string newText)
    {
        if (dialogueText1 != null)
        {
            dialogueText3.text = newText;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI bulunamadı veya atanmadı!");
        }
    }
}