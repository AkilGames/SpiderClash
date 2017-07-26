using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class NewAchievementPanel : MonoBehaviour
{
    public LanguageUIElement text;

    Queue<int> q = new Queue<int>();
    float showTime = 0.5f;
    float delayTime = 3.0f;
    Coroutine showCoroutine = null;

    void Start()
    {
        PlayerAchievements.Instance.onTake += a =>
        {
            q.Enqueue((int)a + 1);
            if (showCoroutine == null)
                showCoroutine = StartCoroutine(ShowQueue());
        };
    }

    IEnumerator ShowQueue()
    {
        while (q.Count > 0)
        {
            text.stringName = string.Format("Achievment{0}Caption", q.Dequeue());
            text.SetLanguage();
            transform.DOLocalMoveY(360.0f, showTime);
            transform.DOLocalMoveY(560.0f, showTime).SetDelay(delayTime);
            yield return new WaitForSeconds(delayTime + showTime * 2.0f);
        }
        showCoroutine = null;
        yield return null;
    }
}