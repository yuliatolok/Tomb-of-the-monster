using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeForSlowDownEffect = 10f;
    [SerializeField] Gun gun;
    [SerializeField] Arbalet arbalet;
    [SerializeField] float amountOffBullet = 4f;
    [SerializeField] float bulletSpeed = 5f;
    Image image;
    
    float timerValue;
    float fillFraction;


    private void Start()
    {
        image = GetComponent<Image>();
        timerValue = 0f;
    }

    void Update()
    {
        UpdateTimer();
        if (Mathf.Approximately(timerValue, 30f))
        {
            gun.ResetFireSpeed();
            arbalet.ResteFireSpeed();
        }
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        fillFraction = timerValue / timeForSlowDownEffect;
        image.fillAmount = fillFraction;
    }

    void ResetTimer()
    {
        timerValue = timeForSlowDownEffect;
    }
    public void EnableSlowDownRegime()
    {
        ResetTimer();
        gun.SetFireSpeed(amountOffBullet, bulletSpeed);
        arbalet.SetArrowSpeed(amountOffBullet, bulletSpeed); 
    }

}
