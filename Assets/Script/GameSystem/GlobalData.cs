using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static int iceQuantity = 10, shellQuantity = 10, glassQuantity = 10, foodQuantity = 10, seahareQuantity, techQuantity = 10,populationSaved=4,loop,cameraShakeTime=0;
    public static float loopTime = 120f;
    public static string status;
    public static bool noOneSelected=true,videoEnd=false;
    public static InteractiveObject[,] arrayData=new InteractiveObject[1000,1000];
    private void Start()
    {
        Reset();
    }
    public static void Reset()
    {
        for (int i = 0; i < arrayData.GetLength(0); i++) 
        {
            for (int j = 0; j < arrayData.GetLength(1); j++) 
            {
                arrayData[i, j] = null;
            }
        }
    }
    public static void BianLi()
    {
        for (int i = 0; i < arrayData.GetLength(0); i++)
        {
            for (int j = 0; j < arrayData.GetLength(1); j++)
            {
                if (arrayData[i, j] != null)
                {
                    Debug.Log(i + "," + j);
                    Debug.Log(arrayData[i, j]);
                }
            }
        }
    }
    public static void Destory()
    {
        for (int i = 0; i < arrayData.GetLength(0); i++)
        {
            for (int j = 0; j < arrayData.GetLength(1); j++)
            {
                if (arrayData[i, j] != null)
                {
                    if (Random.Range(1F, 10F) > 5F) 
                        arrayData[i,j].destroyed = true;
                    //Debug.Log("destroyed");
                }
            }
        }
    }
}
