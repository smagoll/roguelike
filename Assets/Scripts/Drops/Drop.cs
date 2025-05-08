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

    private float time = 30f;
    private Coroutine destroyTimerCoroutine;
    
    private void Awake()
    {
        player = GameManager.player;
    }

    public void StartTimer()
    {
        if (destroyTimerCoroutine != null)
            StopCoroutine(destroyTimerCoroutine);

        destroyTimerCoroutine = StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(time);
        pool.Release(this); // Возвращаем объект в пул
        destroyTimerCoroutine = null;
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
            if (destroyTimerCoroutine != null)
            {
                StopCoroutine(destroyTimerCoroutine);
                destroyTimerCoroutine = null;
            }
            
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

