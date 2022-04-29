using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private Pointer swipeControls;
    [SerializeField] GameObject bombManager;
    [SerializeField] GameObject bomb;
    [SerializeField] Health health;
    [SerializeField] Canvas canvas;

    private bool inBoots = false;
    public bool hasKey;
    public bool isMoving = true;
    bool BombSet = false;
    public bool InBoots => inBoots;

    private void OnEnable()
    {
        health.OnKilled += Kill;
        swipeControls.OnSwipe += Move;
        swipeControls.OnClick += SetBomb;
    }
    private void OnDisable()
    {
        health.OnKilled -= Kill;
        swipeControls.OnSwipe -= Move;
        swipeControls.OnClick -= SetBomb;
    }
    private void Start()
    {
        canvas.enabled = false;
    }

    public void PutBootsOn()
    {
        inBoots = true;
        GetComponent<Animator>().SetBool("Boots", true);
    }
    private void SetBomb()
    {
        if (isMoving && !BombSet)
        {
            swipeControls.IsTaping = false;

            StartCoroutine(Explotion());
        }
    }

    IEnumerator Explotion()
    {
        bomb.SetActive(true);
        bombManager.transform.position = transform.position;
        BombSet = true;
        yield return new WaitForSeconds(4);
        BombSet = false;
    }

    private void Kill()
    {
        isMoving = false;
        canvas.enabled = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Move(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            RaycastHit2D hit =
                Physics2D.Raycast(transform.position, direction, 100f, LayerMask.GetMask("Obstacle"));
            if (hit.collider != null && isMoving)
            {
                if (hit.collider.TryGetComponent<Lava>(out var lava))
                {
                    if (inBoots)
                    {
                        lava.GetComponent<BoxCollider2D>().enabled = false;
                        return;
                    }

                    StartCoroutine(Strafe(hit.point));
                }
                else if (hit.collider.TryGetComponent<Knife>(out var knife))
                    StartCoroutine(Strafe(hit.point - direction));
                else StartCoroutine(Strafe(hit.point - 0.5f * direction));
            }
        }
    }

    private IEnumerator Strafe(Vector2 endPosition)
    {
        while (Vector3.Distance(transform.position, endPosition) > 0.001f)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Vibrator.Vibrate(50);
    }

    public void StopTaping()
    {
        StartCoroutine(StopSettingBombs());
    }

    private IEnumerator StopSettingBombs()
    {
        BombSet = true;
        yield return new WaitForSeconds(1);
        BombSet = false;
    }
}
