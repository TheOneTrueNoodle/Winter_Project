using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool timerRunning = false;

    public float timer = 120f;
    public float reset = 120f;

    void Update()
    {
        if (timerRunning == true)
        {
            timer -= Time.deltaTime % 60f;

            if (timer <= 0)
            {
                timerRunning = false;
            }
        }
    }

    public void Begin()
    {
        timerRunning = true;
        timer = reset;
    }

}
