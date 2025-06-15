using UnityEngine;
using UnityEngine.UI;

public class ClickDestroy : MonoBehaviour
{
    public Image objt;
    public Image foto;
    public void OnClickDestroyClick()
    {
        if (!ClickManage.youWin)
        {
            ClickManage.count += 1;
            SetInactiveImmediateParentAndSelf();
            ClickManage.Instance.Control();
        }
    }

    private void SetInactiveImmediateParentAndSelf()
    {
        objt.gameObject.SetActive(false);
        foto.gameObject.SetActive(false);
    }
}
