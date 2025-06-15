using UnityEngine;

public class LeverControlHorizontal : MonoBehaviour
{
    public PlatformControllerHorizontal platformController;
    [SerializeField] private Animator anim;

    private float yon = -1f;
    private bool isPlayerNearby = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (yon == 1)
            {
                yon = -1f;
                anim.SetFloat("yon", -1f);
                platformController.ButtonActivated();
            }
            else if (yon == -1)
            {
                yon = 1f;
                anim.SetFloat("yon", 1f);
                platformController.ButtonDeactivated();
            }
        }
    }
}
