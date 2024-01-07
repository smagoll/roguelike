using UnityEngine;

public class DropCollector : MonoBehaviour
{
    [SerializeField]
    private float startRadius;
    private float scaleRadius = 0; // в процентах

    private CircleCollider2D circleCollider; 

    public float ScaleRadius
    {
        get { return scaleRadius; }
        set
        {
            scaleRadius = value;
            UpdateRadiusCollider();
        }
    }

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        UpdateRadiusCollider();
    }

    private void UpdateRadiusCollider()
    {
        circleCollider.radius = startRadius + startRadius * scaleRadius / 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Drop"))
        {
            var drop = collision.gameObject.GetComponent<Drop>();
            drop.isAttraction = true;
        }
    }
}
