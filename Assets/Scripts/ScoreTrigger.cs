using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool scored = false;
    public GameManager gameManager;

    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!scored && other.gameObject.name == "stork")
        {
            gameManager.UpdateScore();
            scored = true;
        }
    }

}
