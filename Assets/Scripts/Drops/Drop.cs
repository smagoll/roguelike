using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;

public abstract class Drop : MonoBehaviour
{
    public ObjectPool<Drop> pool;
    private readonly float speed = 4f;
    public int count;
    public bool isAttraction = false;
    public int chance;
    public DropManager.DropType dropType;
    private GameObject player;

    private void Awake()
    {
        player = GameManager.player;
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
            pool.Release(this);
            AudioGame.instance.PlaySmallSFX(AudioGame.instance.dropTake);
        }
    }

    private void OnEnable()
    {
        isAttraction = false;
    }

    public abstract void Action();
}

