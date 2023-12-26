using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropExp : MonoBehaviour
{
    private readonly float speed = 4f;
    public float countXp;
    public bool isMove = false;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isMove)
        {
            var direction = player.transform.position - transform.position;
            transform.position += speed * Time.deltaTime * direction.normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CenterCollector"))
        {
            GlobalEventManager.Start_UpdateXp(countXp);
            Destroy(gameObject);
        }
    }
}
