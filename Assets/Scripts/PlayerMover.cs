using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private Swipe swipeControls;
    [SerializeField] Vibration vibration;
    [SerializeField] GameObject bombManager;
    [SerializeField] GameObject bomb;
    private Vector2 desiredDirection = Vector2.zero;
    Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (swipeControls.SwipeLeft)
            desiredDirection = Vector2.left;
        if (swipeControls.SwipeRight)
            desiredDirection = Vector2.right;
        if (swipeControls.SwipeUp)
            desiredDirection = Vector2.up;
        if (swipeControls.SwipeDown)
            desiredDirection = Vector2.down;

        if (desiredDirection != Vector2.zero)
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, desiredDirection, 100f, LayerMask.GetMask("Obstacle"));
            if (hit.collider != null)
            {
                transform.position = hit.point - desiredDirection;
            }
            desiredDirection = Vector2.zero;
        }
        if (swipeControls.IsTaping)
        { 
            swipeControls.IsTaping = false;

            StartCoroutine(Explotion());
        }

    }

    IEnumerator Explotion()
    {
        bomb.SetActive(true);
        bombManager.transform.position = transform.position;
        Debug.Log("is TAping");
        yield return new WaitForSeconds(1);
    }

}
