using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class AboutPanel : PanelBehaviour, IPointerDownHandler
{
    public Transform content;
    public float scrollDelay = 1.0f, scrollDuration = 10.0f;

    public override void Show()
    {
        base.Show();
        StartScrolling();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StopScrolling();
    }

    void StartScrolling()
    {
        content.transform.localPosition = Vector2.zero;
        content.DOKill();
        GetComponent<Collider2D>().enabled = true;
        content.DOLocalMoveY(372.0f, scrollDuration).SetDelay(scrollDelay).SetEase(Ease.Linear);
    }

    void StopScrolling()
    {
        GetComponent<Collider2D>().enabled = false;
        content.DOKill();
    }
}