using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Drop : MonoBehaviour
{
    private readonly float speed = 4f;
    public bool isAttraction = false;
    public int chance;
    private GameObject player;

    private void Awake()
    {
        player = GameManager.player;
    }

    private void Start()
    {
        Fall();
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

    public void Fall()
    {
        var pointLanding = Random.onUnitSphere * Random.Range(0, 1);
        transform.DOScale(0.2f, 0.05f);
    }
}

