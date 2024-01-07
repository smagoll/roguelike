using UnityEngine;

public class Arrow : Projectile
{
    public Bow bow;
    public bool IsThrough { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(bow.Damage);

            if (!IsThrough)
                Destroy(gameObject);
        }
    }
}
