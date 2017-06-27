using UnityEngine;
using UnityEngine.EventSystems;

public class TapArea : MonoBehaviour, IPointerClickHandler
{
    public Player player;

    public void OnPointerClick(PointerEventData eventData)
    {
        player.CastLine();
    }
}