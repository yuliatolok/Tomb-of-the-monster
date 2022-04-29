using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Fire fire;
    [SerializeField] Transform target;
    [SerializeField] float timeBetweenBullets = 3f;
    Vector3 direction;
    float timeBetweenBulletsBackup;

    void Start()
    {  
        AimWeapon();
        StartCoroutine(Shoot());
    }



    private void AimWeapon()
    {
        fire.gameObject.SetActive(true);    
        direction = (target.position - transform.position).normalized;
   }
    IEnumerator Shoot()
    {
        while (true)
        {
            fire.transform.position = transform.position;
            fire.transform.rotation = transform.rotation;
            fire.Shoot();
            yield return new WaitForSeconds(timeBetweenBullets);
        }

    }
    public void SetFireSpeed(float speed, float amountOffBullet)
    {
        timeBetweenBulletsBackup = this.timeBetweenBullets;
        this.timeBetweenBullets = amountOffBullet;
        fire.SetMoveSpeed(speed);
    }
    public void ResetFireSpeed()
    {
       timeBetweenBullets = timeBetweenBulletsBackup;
       fire.ResetMoveSpeed();
    }

}
