using UnityEngine;
using DG.Tweening;

public class MainPanel : PanelBehaviour
{
    public RectTransform shareButton, rateButton;

    bool isShareButtonHided = true;
    bool isRateButtonHided = true;

    public float showPos;
    public float hidePos;

    public override void Hide()
    {
        base.Hide();
        shareButton.DOLocalMoveX(hidePos, 0.1f);
        rateButton.DOLocalMoveX(hidePos, 0.1f);
        isShareButtonHided = true;
        isRateButtonHided = true;
    }

    public void OnClick(string state)
    {
        MenuManager.Instance.MenuState = (MENUSTATE)System.Enum.Parse(typeof(MENUSTATE), state);
        SoundManager.Instance.PlaySound("Click");
    }

    public void ShareButtonClick()
    {
        SoundManager.Instance.PlaySound("Click");
        if (isShareButtonHided = !isShareButtonHided)
        {
            shareButton.DOLocalMoveX(hidePos, 0.3f);
            //---
        }
        else
        {
            shareButton.DOLocalMoveX(showPos, 0.3f);
            rateButton.DOLocalMoveX(hidePos, 0.3f);
            isRateButtonHided = true;
        }
    }

    public void RateButtonClick()
    {
        SoundManager.Instance.PlaySound("Click");
        if (isRateButtonHided = !isRateButtonHided)
        {
            rateButton.DOLocalMoveX(hidePos, 0.3f);
            //---
        }
        else
        {
            rateButton.DOLocalMoveX(showPos, 0.3f);
            shareButton.DOLocalMoveX(hidePos, 0.3f);
            isShareButtonHided = true;
        }
    }
}
