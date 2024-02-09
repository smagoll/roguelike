using System.Linq;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public bool isEnd = false;
    public Stat[] stats;
    public Weapon weapon;
    public Enemy enemy;

    public float Duration { get; set; }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        Duration = stats.FirstOrDefault(x => x.Type == StatType.Duration).GetValue();
        ActionStart();
    }

    private void Update()
    {
        if (enemy.isDeath)
        {
            if (!isEnd)
            {
                ActionEnd();
                isEnd = true;
            }
            return;
        }

        ActionUpdate();

        Duration -= Time.deltaTime;

        if (Duration <= 0)
        {
            ActionEnd();
            Destroy(this);
        }
    }

    public virtual void ActionUpdate() { }
    public virtual void ActionStart() { }
    public virtual void ActionEnd() { }
}
