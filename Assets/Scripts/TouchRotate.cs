using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameMan.youWin)
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
}
