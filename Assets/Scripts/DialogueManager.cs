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
        }
    }

    public void SetDialogueText(string newText)
    {
        if (dialogueText1 != null)
        {
            dialogueText1.text = newText;
        }
    } public void SetDialogueText1(string newText)
    {
        if (dialogueText2 != null)
        {
            dialogueText2.text = newText;
        }
    }

    public void SetDialogueText2(string newText)
    {
        if (dialogueText1 != null)
        {
            dialogueText3.text = newText;
        }
    }
}