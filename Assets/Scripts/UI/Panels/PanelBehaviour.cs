using UnityEngine;

public class PanelBehaviour : MonoBehaviour, IPanel
{
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
}