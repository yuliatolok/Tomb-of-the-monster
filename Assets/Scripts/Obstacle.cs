using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Sprite spriteDestroy;
    [SerializeField] Health health;

    private void OnEnable()
    {
        health.OnKilled += Explode;
    }
    private void Explode()
    {
        GetComponent<SpriteRenderer>().sprite = spriteDestroy;
        GetComponent<BoxCollider2D>().enabled = false;  
    }
    private void OnDisable()
    {
        health.OnKilled -= Explode;
    }
}
