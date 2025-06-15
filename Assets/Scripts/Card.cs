using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;
    public Sprite iconSprite;

    public bool isSelected;
    public bool isMatched;

    public CardController controller;

    public void OnCardClick()
    {
        if (isMatched) return;
        controller.SetSelected(this);
    }

    public void SetIconSprite(Sprite sp)
    {
        iconSprite = sp;
    }

    public void Show()
    {
        iconImage.sprite = iconSprite;
        SetImageTransparency(1.0f);
        isSelected = true;
    }

    public void Hide()
    {
        if (isMatched) return;
        SetImageTransparency(0.0f);
        isSelected = false;
    }

    private void SetImageTransparency(float alpha)
    {
        if (iconImage != null)
        {
            Color color = iconImage.color;
            color.a = Mathf.Clamp01(alpha);
            iconImage.color = color;
        }
    }
}
