using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnKilled;
    public void Kill()
    { 
    OnKilled?.Invoke();
    }
}
