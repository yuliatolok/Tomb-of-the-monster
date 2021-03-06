using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject smokeManager;

    PolygonCollider2D polygonCollider2D;

    private void OnEnable()
    {
        StartCoroutine(Explotion());
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }
    IEnumerator Explotion()
    {
        yield return new WaitForSeconds(2f);
        smokeManager.SetActive(true);
        polygonCollider2D.enabled = true;
        Handheld.Vibrate();
        yield return new WaitForSeconds(2f);
        smokeManager.SetActive(false);
        gameObject.SetActive(false);
        polygonCollider2D.enabled = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<Health>(out var heath))
        {
            heath.Kill();
        }
      
    }
}
