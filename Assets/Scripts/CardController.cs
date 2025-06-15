using UnityEngine;
using System.Collections;
using TMPro;

public class CardController : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] Transform gridTransform;
    [SerializeField] private TextMeshProUGUI winText;

    public Collider2D puzzleCollider;

    private int activeCards = 8;

    Card firstSelected;
    Card secondSelected;
    [SerializeField] private PlatformControllerVertical platformController;

    private void Start()
    {
        winText.gameObject.SetActive(false);
        CreateCards();
        
    }

    private void CreateCards()
    {
    }

    public void SetSelected(Card card)
    {
        if (!card.isSelected)
        {
            card.Show();

            if (firstSelected == null)
            {
                firstSelected = card;
                return;
            }

            if (secondSelected == null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    private IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.9f);

        if (a.iconSprite == b.iconSprite)
        {
            a.isMatched = true;
            b.isMatched = true;

            a.Show();
            b.Show();

            activeCards -= 2;

            if (activeCards == 0)
            {
                StartCoroutine(ShowWinMessage());
            }
        }
        else
        {
            a.Hide();
            b.Hide();
        }
    }

    private IEnumerator ShowWinMessage()
    {
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        canvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);

        if (platformController != null)
        {
            platformController.ButtonActivated();
        }

        if (puzzleCollider != null)
        {
            Destroy(puzzleCollider);
        }

        yield return new WaitForSeconds(1f);

        if (platformController != null)
        {
            platformController.ButtonActivated();
        }
    }
}
