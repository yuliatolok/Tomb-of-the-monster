using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject lockManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerMover>().hasKey)
            {
                Destroy(lockManager);
                Destroy(gameObject);
            }
        }
    }
}
