using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Sprite spriteDestroy;
    public void Explode()
    {
        GetComponent<SpriteRenderer>().sprite = spriteDestroy;
        GetComponent<BoxCollider2D>().enabled = false;  
    }
}
