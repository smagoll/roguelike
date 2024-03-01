using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Enemy
{
    public override void Attack()
    {
        var players = Physics2D.OverlapCircleAll(gameObject.transform.position, distanceStop);
        foreach (var player in players)
        {
            if (player.CompareTag("Player"))
            {
                var character = player.GetComponent<Character>();
                character.TakeDamage(damage);
                AudioGame.instance.PlaySmallSFX(AudioGame.instance.stoneExplosion);
                EffectManager.instance.CreateStoneExplosion(transform);
                DestroyEnemy();
            }
        }
    }
}
