using UnityEngine;
using UnityEngine.Playables;
using TMPro;


public class DialogueController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public TextMeshProUGUI dialogueTextUI;
    public string[] dialogues;

    public void StartDialogue()
    {
        playableDirector.Play();
    }
}
