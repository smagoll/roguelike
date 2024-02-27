using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.VFX;

public class Field : MonoBehaviour
{
    public MagneticField controller;
    public float lastTimeAttack = 0f;
    public List<GameObject> enemies = new();
    private Vector3 scale;
    [SerializeField]
    private VisualEffect impulse;

    private void Awake()
    {
        scale = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        var enemiesCopy = new List<GameObject>(enemies);
        if (Time.time - lastTimeAttack > controller.Frequency)
        {
            lastTimeAttack = Time.time;
            impulse.SendEvent("OnPlay");
            AudioGame.instance.PlayMainSFX(AudioGame.instance.magneticFieldPulse);

            if (enemiesCopy.Count == 0)
                return;

            foreach (var enemy in enemiesCopy)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(controller.damage);
                }
            }
        }
    }

    public void UpdateScale(float scaleScale)
    {
        transform.localScale = scale * (scaleScale) / 100;
    }
}
