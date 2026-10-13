using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHandRotator : MonoBehaviour
{
    void Update()
    {
        if (LoopTimerController.instance == null) return;

        float timer = LoopTimerController.instance.timer;
        float interval = LoopTimerController.instance.interval;


        float angle = (timer / interval) * 360f;

        transform.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
