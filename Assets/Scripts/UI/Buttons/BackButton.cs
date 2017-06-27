using UnityEngine;

public class BackButton : MonoBehaviour
{
    public virtual void Back()
    {
        MenuManager.Instance.Back();
    }
}