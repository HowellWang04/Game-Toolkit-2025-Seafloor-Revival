using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopTimerController : MonoBehaviour
{
    public static LoopTimerController instance;
    public TextMeshProUGUI loopText;
    public float interval = GlobalData.loopTime;
    public float timer = 0f;
    public bool isRunning = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            GlobalData.loop++;
            updateLoopText(GlobalData.loop);
        }
    }

    public void runLoopTimer(int startLoop)
    {
        GlobalData.loop = startLoop;
        updateLoopText(startLoop);
        timer = 0f;
        isRunning = true;
    }

    public void stopLoopTimer()
    {
        isRunning = false;
    }

    public void resetLoopAndTimer()
    {
        GlobalData.loop = 1;
        timer = 0f;
        updateLoopText(GlobalData.loop);
    }

    private void updateLoopText(int loop)
    {
        loopText.text = $"Loop {loop}";
    }
}

