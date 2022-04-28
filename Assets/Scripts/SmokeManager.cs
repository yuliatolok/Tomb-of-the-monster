using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeManager : MonoBehaviour
{
    [SerializeField] List<GameObject> smokeParticlesUp;
    [SerializeField] List<GameObject> smokeParticlesDown;
    [SerializeField] List<GameObject> smokeParticlesRight;
    [SerializeField] List<GameObject> smokeParticlesLeft;
    [SerializeField] int smokeSize = 4;
    private int distanceRight, distanceLeft, distanceDown, distanceUp;
    RaycastHit2D hit;

    void OnEnable()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, 200, LayerMask.GetMask("Obstacle"));
        if (hit.collider != null) distanceDown = (int)hit.distance;
        hit = Physics2D.Raycast(transform.position, Vector2.up, 200, LayerMask.GetMask("Obstacle"));
        if (hit.collider != null) distanceUp = (int)hit.distance;
        hit = Physics2D.Raycast(transform.position, Vector2.right, 200, LayerMask.GetMask("Obstacle"));
        if (hit.collider != null) distanceRight = (int)hit.distance;
        hit = Physics2D.Raycast(transform.position, Vector2.left, 200, LayerMask.GetMask("Obstacle"));
        if (hit.collider != null) distanceLeft = (int)hit.distance;
        Debug.Log(distanceDown + " " + distanceUp + " " + distanceLeft + " " + distanceRight);
        
        StartCoroutine(GenerateSmoke());


    }

    IEnumerator GenerateSmoke()
    {
        for (int i = 0; i < distanceDown && i < smokeSize; i++)
        {
            smokeParticlesDown[i].SetActive(true);
        }
        for (int i = 0; i < distanceUp && i < smokeSize; i++)
        {
            smokeParticlesUp[i].SetActive(true);
        }
        for (int i = 0; i < distanceRight && i < smokeSize; i++)
        {
            smokeParticlesRight[i].SetActive(true);
        }
        for (int i = 0; i < distanceLeft && i < smokeSize; i++)
        {
            smokeParticlesLeft[i].SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);
        foreach (var item in smokeParticlesUp)
        {
            item.SetActive(false);  
        }
        foreach (var item in smokeParticlesDown)
        {
            item.SetActive(false);
        }
        foreach (var item in smokeParticlesRight)
        {
            item.SetActive(false);
        }
        foreach (var item in smokeParticlesLeft)
        {
            item.SetActive(false);
        }
    }

}
