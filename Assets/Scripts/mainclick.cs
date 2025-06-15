using UnityEngine;

public class mainclick : MonoBehaviour
{
    public Canvas canvas;
    public void OnClickactive()
    {
        canvas.gameObject.SetActive(true);
    }

    public void OnClickpasif()
    {
        canvas.gameObject.SetActive(false);
    }
}
