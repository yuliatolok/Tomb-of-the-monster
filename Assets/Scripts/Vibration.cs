using UnityEngine;
using System.Collections;


public class Vibration : MonoBehaviour
{
    private bool isVibration = false;
    private void PlayVibration()
    {
        
    }

    public void PlayerVibrate(float time)
    {
        StartCoroutine(vibrationTime(time));
    }
    private IEnumerator vibrationTime(float time)
    {
        isVibration = true;
        yield return new WaitForSeconds(time);
        isVibration = false;
    }
}
