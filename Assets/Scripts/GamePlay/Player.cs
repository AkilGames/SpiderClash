using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public float castSpeed = 0.0f;
    public float pullSpeed = 0.2f;
    public LineRenderer line;
    public GameObject paws;
    public Transform body;

    bool isPulling = false;
    bool isCasting = false;
    Vector2  touchPos;
    RaycastHit2D ray, temp;
    Tweener pullTweener, castTweener;
    SpringJoint2D join;

    [Range(0.0f, 1.0f)]
    float k;

    void Start()
    {
        join = GetComponent<SpringJoint2D>();
    }

    static Vector2 Lerp(Vector2 from, Vector2 to, float k)
    {
        return from + (to - from) * k;
    }

    void FixedUpdate()
    {
        line.SetPosition(0, transform.position);
        body.eulerAngles = Vector3.zero;

        if (isPulling)
        {
            if (RecastLine())
                join.distance = temp.distance;
            line.SetPosition(1, ray.point);
        }
        if (isCasting)
        {
            if (RecastLine())
            {
                isCasting = false;
                isPulling = join.enabled = true;
            }
        }
    }

    public void CastLine()
    {
        ResetLine();
        SoundManager.Instance.PlaySound("Web");
        touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ray = Physics2D.Raycast(transform.position, touchPos - (Vector2)transform.position, 20f, LayerMask.GetMask("Intersectable"));
        join.connectedBody = ray.rigidbody;
        join.distance = ray.distance;
        join.connectedAnchor = new Vector2(ray.point.x - ray.transform.position.x * ray.transform.localScale.x, ray.point.y - ray.transform.position.y * ray.transform.localScale.y);

        isCasting = line.enabled = true;
        line.SetPosition(0, transform.position);

        castTweener = DOTween.To(() => k, v => line.SetPosition(1, Lerp(transform.position, ray.point, k = v)), 1.0f, castSpeed * ray.distance).OnComplete(() =>
        {
            isCasting = false;
            if (ray.collider.tag == "Wall" || ray.collider.tag == "Box" ||  ray.collider.tag == "Adhesive")
            {
                isPulling = join.enabled = true;
                Pull();
            }
            if (ray.collider.tag == "Smooth")
                ResetLine();
        });
    }

    void Pull()
    {
        pullTweener = DOTween.To(() => join.distance, d => join.distance = d, 0.0f, ray.distance * pullSpeed);
    }

    bool RecastLine()
    {
        temp = Physics2D.Raycast(transform.position, ray.point - (Vector2)transform.position, 20f, LayerMask.GetMask("Intersectable"));
        if (Vector2.Distance(temp.point, ray.point) > 0.1f)
        {
            pullTweener.Kill();
            join.connectedBody = temp.rigidbody;
            ray = temp;
            join.connectedAnchor = new Vector2(ray.point.x - ray.transform.position.x * ray.transform.localScale.x, ray.point.y - ray.transform.position.y * ray.transform.localScale.y);
            Pull();
            return true;
        }
        return false;
    }

    void ResetLine()
    {
        k = 0;
        pullTweener.Kill();
        castTweener.Kill();
        join.connectedBody = null;
        join.connectedAnchor = Vector2.zero;
        join.enabled = isPulling = isCasting = line.enabled = false;
    }
}