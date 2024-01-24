using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Hero")]
public class Hero : ScriptableObject
{
    [SerializeField]
    private int id;

    public Sprite sprite;
    public int hp;
    public float speed;
    public float evasion;
    public RuntimeAnimatorController animator;
    public UpgradeWeapon weapon;

    public int Id => id;
    public bool IsOpen => DataManager.instance.gameData.heroes.Where(x => x.id == id).FirstOrDefault().isOpen;
}
