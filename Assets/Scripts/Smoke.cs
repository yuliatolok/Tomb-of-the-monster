using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Smoke : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        Debug.Log(collision.tag);

        if (collision.CompareTag("Explotioning"))
        {
            if (collision.gameObject.TryGetComponent<Obstacle>(out var obstacle))
            {
                obstacle.Explode();
            }
         
        }   
        if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(0);
            }
    }
}
