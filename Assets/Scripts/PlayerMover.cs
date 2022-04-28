using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private Swipe swipeControls;
    [SerializeField] Vibration vibration;
    [SerializeField] GameObject bombManager;
    [SerializeField] GameObject bomb;
    [SerializeField] Health health;
    [SerializeField] Canvas canvas; 
    public bool inBoots = false;
    private Vector2 desiredDirection = Vector2.zero;
    bool isMoving = true;
    Rigidbody2D rb2D;
    private void OnEnable()
    {
        health.OnKilled += Kill;
    }
    private void OnDisable()
    {
        health.OnKilled -= Kill;
    }
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        canvas.enabled = false;
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
            if (hit.collider != null && isMoving)
            {
                if (hit.collider.TryGetComponent<Boots>(out var boots)) StartCoroutine(Move(hit.point));
                else if(hit.collider.TryGetComponent<Lava>(out var lava)) StartCoroutine(Move(hit.point));
                else StartCoroutine(Move(hit.point- desiredDirection)); 
            }
            desiredDirection = Vector2.zero;
        }
        if (swipeControls.IsTaping && isMoving)
        { 
            swipeControls.IsTaping = false;

            StartCoroutine(Explotion());
        }
        if (inBoots)
        {
            GetComponent<Animator>().SetBool("Boots", true);
        }
    }

    IEnumerator Explotion()
    {
        bomb.SetActive(true);
        bombManager.transform.position = transform.position;
        yield return new WaitForSeconds(1);
    }
    void Kill()
    {
        isMoving = false;
        canvas.enabled = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator Move(Vector2 endPosition)
    {
        Vector2 startPosition = transform.position;
        
        while (Vector3.Distance(transform.position, endPosition) > 0.001f)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        
        //float step = 0.01f * moveSpeed * Time.deltaTime;
        //for (float i = 0; i < 1; i+=step)
        //{
        //    transform.position = Vector2.Lerp(startPosition, endPosition, i);
        //    yield return null;
        //}
    }
}
