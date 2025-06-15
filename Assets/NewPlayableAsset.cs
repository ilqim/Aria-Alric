using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "New DialoguePlayableAsset", menuName = "Dialogue/PlayableAsset")]
public class NewPlayableAsset : ScriptableObject
{
    public string dialogueText;        // Konuşma metni
    public float typingSpeed = 0.05f;  // Harf yazım hızı

    // Bu asset'i Timeline'da kullanmak için Playable oluşturma
    public Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialoguePlayableBehaviour>.Create(graph);

        DialoguePlayableBehaviour behaviour = playable.GetBehaviour();
        behaviour.dialogueText = dialogueText;
        behaviour.typingSpeed = typingSpeed;

        return playable;
    }
}
