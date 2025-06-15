using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Playables;

public class DialoguePlayableBehaviour : PlayableBehaviour
{
    public string dialogueText;
    public float typingSpeed;
    public TextMeshProUGUI dialogueTextUI;

    private bool isTyping;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (!isTyping && dialogueTextUI != null)
        {
            isTyping = true;
            dialogueTextUI.text = "";
            dialogueTextUI.StartCoroutine(TypeText());
        }
    }

    private IEnumerator TypeText()
    {
        foreach (char c in dialogueText.ToCharArray())
        {
            dialogueTextUI.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
