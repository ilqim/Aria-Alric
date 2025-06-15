using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class GameMan : MonoBehaviour
{
    [SerializeField]
    private List<Transform> pictures;

    [SerializeField]
    private TextMeshProUGUI winText;

    public static bool youWin;

    public GameObject parchament;

    public Collider2D puzzleCollider;
    [SerializeField] private PlatformControllerVertical platformController;
    void Start()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }

        youWin = false;

        if (platformController == null)
        {
            Debug.LogError("PlatformController is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        bool allAligned = true;
        foreach (Transform picture in pictures)
        {
            if (Mathf.Abs(picture.rotation.eulerAngles.z) > 0.1f)
            {
                allAligned = false;
                break;
            }
        }

        if (allAligned && !youWin)
        {
            youWin = true;
            winText.gameObject.SetActive(true);
            StartCoroutine(HideParchamentAfterDelay(3f));
        }
    }

    private IEnumerator HideParchamentAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        parchament.SetActive(false);

        if (puzzleCollider != null)
        {
            Destroy(puzzleCollider);
        }

        yield return new WaitForSeconds(delay / 3);

        if (platformController != null)
        {
            platformController.ButtonActivated();
        }
    }
}
