using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAd : MonoBehaviour
{
    private DateTime lastTime;
    
    private void Start()
    {
        lastTime = DateTime.Now.ToLocalTime();
    }

    public void Qwe()
    {
        var b = DateTime.Now.Subtract(lastTime);
        Debug.Log(b.ToString()+ " b");
    }
}
