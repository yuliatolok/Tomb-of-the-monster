using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbalet : MonoBehaviour
{
    [SerializeField] Arrow arrow;
    [SerializeField] Transform target;
    float amountOffBullet = 3f;
    float amountOffBulletBackup;

    float angle;
    void Start()
    {
        arrow.gameObject.SetActive(true);
        StartCoroutine(Shoot());
    }

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
            yield return new WaitForSeconds(amountOffBullet);
        }

    }
    public void SetArrowSpeed(float speed, float amountOffBullet)
    {
        amountOffBulletBackup = this.amountOffBullet;
        this.amountOffBullet = amountOffBullet;
        arrow.SetMoveSpeed(speed);
    }
    public void ResteFireSpeed()
    {
        amountOffBullet = amountOffBulletBackup;
        arrow.ResetMoveSpeed();
    }
}
