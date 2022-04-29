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
    private int distanceRight = 4, distanceLeft = 4, distanceDown = 4, distanceUp = 4;
    RaycastHit2D hit;
    int distance;

    void OnEnable()
    {
        distanceDown = CheckWalls(Vector2.down);
        distanceUp = CheckWalls(Vector2.up);
        distanceRight = CheckWalls(Vector2.right);
        distanceLeft = CheckWalls(Vector2.left);

        StartCoroutine(GenerateSmoke());


    }

    private int CheckWalls(Vector2 direction)
    {
        
        hit = Physics2D.Raycast(transform.position, direction, 200, LayerMask.GetMask("Obstacle"));
        if (hit.collider != null && hit.collider.CompareTag("Walls")) distance = (int)hit.distance;
        else if (hit.collider != null) distance = (int)hit.distance + 1;
        else distance = 4;
        return distance;
    }

    IEnumerator GenerateSmoke()
    {
        SetSmokeActive(distanceDown, smokeParticlesDown);
        SetSmokeActive(distanceUp, smokeParticlesUp);
        SetSmokeActive(distanceRight, smokeParticlesRight);
        SetSmokeActive(distanceLeft, smokeParticlesLeft);
        

        yield return new WaitForSeconds(1.5f);

        SetSmokeDisactive(smokeParticlesUp);
        SetSmokeDisactive(smokeParticlesDown);
        SetSmokeDisactive(smokeParticlesRight);
        SetSmokeDisactive(smokeParticlesLeft);
    }

    void SetSmokeDisactive(List<GameObject> gameObjects)
    {
        foreach (var item in gameObjects)
        {
            item.SetActive(false);
        }
    }
    void SetSmokeActive(int distance, List<GameObject> gameObjects)
    {
        for (int i = 0; i < distance && i < smokeSize; i++)
        {
            gameObjects[i].SetActive(true);
        }
    }
}
