using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
        public static AndroidJavaClass unityplayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        public static AndroidJavaObject currentActivity = unityplayer.GetStatic<AndroidJavaObject>("currentActivity");
        public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityplayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate(long milliseconds = 250)
    {
        if (Isandroid())
        {
            vibrator.Call("vibrate", milliseconds);
        }
        else
            Vibrator.Vibrate(150);

    }
    public static void Cancel()
    {
        if (Isandroid())
        {
            vibrator.Call("cancel");
        }
    }
    public static bool Isandroid()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
        return true;
        #else
        return false;
        #endif
    }
}
