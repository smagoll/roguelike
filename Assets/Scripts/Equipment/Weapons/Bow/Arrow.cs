using UnityEngine;

public class Arrow : Projectile
{
    public Bow bow;
    private bool isHit = false;
    public bool IsThrough { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit && !IsThrough)
            return;

        if (collision.CompareTag("Enemy"))
        {
            isHit = true;
            collision.GetComponent<Enemy>().TakeDamage(bow.Damage);

            if (!IsThrough)
                Destroy(gameObject);
        }
    }
}
