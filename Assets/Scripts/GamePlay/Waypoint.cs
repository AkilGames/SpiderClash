using DG.Tweening;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform arrow;
    public bool isEnabled;

    void Start()
    {
        if (isEnabled)
            Activate();
    }

    public void Activate()
    {
        arrow.DOLocalMoveY(0.5f, 0.2f).OnComplete(MoveDown);
    }

    void MoveUp()
    {
        arrow.DOLocalMoveY(0.5f, 0.4f).OnComplete(MoveDown);
    }

    void MoveDown()
    {
        arrow.DOLocalMoveY(0.3f, 0.4f).OnComplete(MoveUp);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Collider2D>().enabled = false;
            Invoke("Complete", 0.5f);
        }
    }

    void Complete()
    {
        LevelController.Current.CompleteLevel();
    }
}