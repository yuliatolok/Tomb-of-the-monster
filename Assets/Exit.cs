using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            canvas.enabled = true;
            collision.GetComponent<PlayerMover>().isMoving = false;
        }
    }
}
