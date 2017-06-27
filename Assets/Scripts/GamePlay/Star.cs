using DG.Tweening;
using UnityEngine;

public class Star : MonoBehaviour
{
    public bool isTimer;
    public float time;
    public Transform arrow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Complete().OnComplete(()=>
            {
                SoundManager.Instance.PlaySound("Star");
                gameObject.SetActive(false);
                LevelController.Current.AddStar();
            });
        }
    }
    void Start()
    {
        if (isTimer)
        {
            arrow.gameObject.SetActive(true);
            arrow.DORotate(new Vector3(0.0f, 0.0f, -360.0f), time, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).OnComplete(()=>
            {
                Complete();
            });
        }
    }

    Tweener Complete()
    {
        if (isTimer)
        {
            transform.DOKill();
            arrow.gameObject.SetActive(false);
            arrow.DOKill();
        }
        transform.DOPunchScale(new Vector2(10.0f, 10.0f), 0.4f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
        return GetComponent<SpriteRenderer>().DOFade(0.0f, 0.4f);
    }
}