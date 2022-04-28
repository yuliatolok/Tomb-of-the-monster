using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    bool isFlying;
    void Update()
    {
        if (isFlying)
        {
            transform.Translate(Vector3.up * Time.deltaTime, Space.Self);
        }
    }

    public void Explode()
    {
        isFlying = false;
        gameObject.SetActive(false);

    }
    public void Shoot()
    {
        isFlying = true;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
    }

}
