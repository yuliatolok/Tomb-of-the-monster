using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbalet : MonoBehaviour
{
    [SerializeField] Arrow arrow;
    [SerializeField] Transform target;
   

    float angle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();

    }

    private void AimWeapon()
    {
        Vector3 direction = target.position - transform.position;
         angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            arrow.transform.position = transform.position;
            arrow.transform.rotation = transform.rotation;
            arrow.Shoot();
            yield return new WaitForSeconds(3);
        }

    }

}
