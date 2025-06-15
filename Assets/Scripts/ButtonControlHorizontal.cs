using UnityEngine;

public class ButtonControlHorizontal : MonoBehaviour
{
    public PlatformControllerHorizontal platformController;
    [SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            anim.SetBool("isactive", true);
            platformController.ButtonActivated();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            anim.SetBool("isactive", false);
            platformController.ButtonDeactivated();
        }
    }
}
