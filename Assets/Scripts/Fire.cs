using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float moveSpeed = 3f;
    bool isFlying;
    float moveSpeedBackUp;
    

    void Update()
    {
        if (isFlying)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed, Space.Self);
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
        if (collision.TryGetComponent<Health>(out var health) && collision.CompareTag("Player"))
        {
            health.Kill();
        }
        if (!collision.CompareTag("Ignore")) Explode(); 

    }
    public void SetMoveSpeed(float speed)
    {
        moveSpeedBackUp = moveSpeed;
        moveSpeed = speed;
    }
    public void ResetMoveSpeed()
    {
        moveSpeed = moveSpeedBackUp;
    }

}
