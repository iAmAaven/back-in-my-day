using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGToPlayerOnTrigger : MonoBehaviour
{
    public int damageToPlayer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // todo WHEN PLAYER HP IS MADE, TAKE DAMAGE

            Destroy(gameObject);
        }
    }
}
