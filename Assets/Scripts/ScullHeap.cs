using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScullHeap : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject player;
    [SerializeField] Sprite exploaded;


    private void OnEnable()
    {
        health.OnKilled += Explode;
    }
    private void OnDisable()
    {
        health.OnKilled -= Explode;
    }
    private void Explode()
    {
        GetComponent<SpriteRenderer>().sprite = exploaded;
        player.GetComponent<Health>().Kill();

    }

}
