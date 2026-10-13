using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InGameBGMController : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioClip bgmClip;

    private int lastLoop = -1;

    void Start()
    {
        if (bgmSource != null && bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.Play();
        }
        lastLoop = GlobalData.loop;
    }

    void Update()
    {
        if (GlobalData.loop != lastLoop)
        {
            restartBGM();
            lastLoop = GlobalData.loop;
        }
    }

    private void restartBGM()
    {
        if (bgmSource == null || bgmClip == null)
        {
            return;
        }
        bgmSource.Stop();
        bgmSource.Play();  
    }
}
