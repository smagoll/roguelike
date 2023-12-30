using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Bow bow;
    public Vector2 direction;
    private Vector2 startPosition;

    public void Flight()
    {
        transform.Translate(bow.speedFlightArrow * Time.deltaTime * direction);
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        var distanceFlight = (new Vector2(transform.position.x, transform.position.y) - startPosition).magnitude;
        if (distanceFlight > bow.distanceFlight)
        {
            Destroy(gameObject);
        }
        Flight();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(bow.damage);
            Destroy(gameObject);
        }
    }
}
