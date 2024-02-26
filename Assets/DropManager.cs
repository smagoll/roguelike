using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class DropManager : MonoBehaviour
{
    public enum DropType
    {
        XP,
        HP,
        Coin
    }

    [SerializeField]
    private Transform dropsTransfrom;
    private List<DropInfo> poolsDrop = new();
    public Drop[] drops;

    private void Awake()
    {
        foreach (var drop in drops) poolsDrop.Add(new DropInfo(drop.chance, drop, drop.dropType, dropsTransfrom));
        GlobalEventManager.SpawnDrop.AddListener(SpawnDrop);
    }

    private void SpawnDrop(DropType dropType, Vector2 position)
    {
        poolsDrop.FirstOrDefault(x => x.dropType == dropType).Spawn(position);
    }
}

public class DropInfo
{
    public ObjectPool<Drop> pool;
    public DropManager.DropType dropType;
    public int chance;

    public DropInfo(int chance, Drop drop, DropManager.DropType dropType, Transform transform)
    {
        this.chance = chance;
        this.dropType = dropType;
        pool = GameManager.CreatePool<Drop>(drop, transform);
    }

    public void Spawn(Vector2 position)
    {
        if (Random.Range(0, 100) <= chance)
        {
            var drop = pool.Get();
            drop.pool = pool;
            drop.transform.position = position;
        }
    }
}
