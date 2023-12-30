using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    private readonly float speed = 4f;
    public bool isAttraction = false;
    public int chance;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isAttraction)
        {
            var direction = player.transform.position - transform.position;
            transform.position += speed * Time.deltaTime * direction.normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CenterCollector"))
        {
            Action();
            Destroy(gameObject);
        }
    }

    public abstract void Action();
}

