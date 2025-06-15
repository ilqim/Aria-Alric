using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text ScoreText;

    public SceneChange SC;
    public Image img;
    public Text txt;

    public GameObject player;

    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();
    }

    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();

        if (score >= 50)
        {
            player.SetActive(false);
            txt.gameObject.SetActive(true);
            img.gameObject.SetActive(true);
            SC.StartCoroutine(SC.SceneTransition());

        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("sahne");
    }

    public void UpdateScore5()
    {
        score += 5;
        ScoreText.text = score.ToString();

        if (score >= 50)
        {
            player.SetActive(false);
            txt.gameObject.SetActive(true);
            img.gameObject.SetActive(true);
            SC.StartCoroutine(SC.SceneTransition());
        }
    }
}
