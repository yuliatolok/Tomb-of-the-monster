using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            PlayerMover player = collision.GetComponent<PlayerMover>();
            if (!player)
                return;

            if (!player.InBoots)
            {
                collision.GetComponent<Health>().Kill();
            }
        }
    }
}
