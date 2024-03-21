using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int enemyHitPoints;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "MinigunBullet")
        {
            Destroy(collider.gameObject);
            enemyHitPoints--;
            if (enemyHitPoints <= 0)
            {
                EnemyDeath();
            }
        }
    }

    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
