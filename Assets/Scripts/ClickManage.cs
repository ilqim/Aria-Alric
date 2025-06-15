using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class ClickManage : MonoBehaviour
{
    public static ClickManage Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI winText;

    public static bool youWin = false;
    public Image parchament;
    public Collider2D puzzleCollider;
    [SerializeField] private PlatformControllerVertical platformController;

    [SerializeField]
    public static int count;

    public Canvas cnvs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Control()
    {
        if (count == 3)
        {
            youWin = true;
            winText.gameObject.SetActive(true);
            StartCoroutine(HideParchamentAfterDelay(3f));
        }
    }

    private IEnumerator HideParchamentAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        parchament.gameObject.SetActive(false);

        if (puzzleCollider != null)
        {
            cnvs.gameObject.SetActive(false);
            Destroy(puzzleCollider);
        }

        yield return new WaitForSeconds(delay / 3);

        if (platformController != null)
        {
            platformController.ButtonActivated();
        }
    }
}
