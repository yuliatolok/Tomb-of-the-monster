using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] GameObject destroyed;
    bool isFlying;
    void Update()
    {
        if (isFlying)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.Self);
        }
    }

    public void Explode()
    {
        isFlying = false;
        gameObject.SetActive(false);
        destroyed.SetActive(true);
        destroyed.transform.position = transform.position;

        Invoke("disableDestroyed", 2f);
    }
    public void Shoot()
    {
        
        isFlying = true;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health) && collision.CompareTag("Player"))
        {
            health.Kill();
        }
        Explode();

    }
    private void disableDestroyed()
    {
        destroyed.SetActive(false);

    }

}
