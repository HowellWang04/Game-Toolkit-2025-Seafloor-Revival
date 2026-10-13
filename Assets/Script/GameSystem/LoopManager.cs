using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    public GameObject populationPrefab, ice, shell,r1,r2,r3,r4;
    bool guiNeed = false;
    int loop = 1;
    Texture2D rectTexture;
    void Start()
    {
        Application.targetFrameRate = 60;
        LoopTimerController.instance.resetLoopAndTimer();
        StartCoroutine(EnterLoop());
        rectTexture = new Texture2D(1, 1);
        rectTexture.SetPixel(0, 0, Color.black);
        rectTexture.Apply();
    }
    void ClearAll()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("resources");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        objs = GameObject.FindGameObjectsWithTag("character");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
    }
    void Update()
    {
        ResourceBarUI.instance.NumUpdate();

        BottomBarUI.instance.uiUpdateSeahareNumText(GlobalData.seahareQuantity);

        BottomBarUI.instance.uiUpdatShelterPopulationText(GlobalData.populationSaved);

        TechPanelUIController.instance.uiUpdateShelterNum(GlobalData.populationSaved);

    }
    IEnumerator EnterLoop()
    {
        LoopTimerController.instance.runLoopTimer(GlobalData.loop);
        GlobalData.loop = loop;

        GlobalData.Destory();
        GlobalData.seahareQuantity = GlobalData.populationSaved;
        ClearAll();
        for (int i = 0; i < GlobalData.populationSaved; i++)
        {
            GameObject clone = Instantiate(populationPrefab, new Vector3(transform.position.x + Random.Range(-5f, 5f), transform.position.y + Random.Range(-5f, 5f), 0f), Quaternion.identity);
        }
        GlobalData.populationSaved = 0;
        int ran = Random.Range(8, 15);
        for (int i = 0; i < ran; i++)
        {
            GameObject obj = Instantiate(ice);
            Combustible_Ice script = obj.GetComponent<Combustible_Ice>();
            obj.tag = "resources";
            script.Init(-17, 9, -11, 14);
        }
        ran = Random.Range(8, 15);
        for (int i = 0; i < ran; i++)
        {
            GameObject obj = Instantiate(shell);
            Shell_Cluster script = obj.GetComponent<Shell_Cluster>();
            obj.tag = "resources";
            script.Init(-17, 9, -11, 14);
        }
        ran = Random.Range(0, 3);
        if (ran < 2)
        {
            GameObject obj = Instantiate(r1);
            ruin1 script = obj.GetComponent<ruin1>();
            obj.tag = "resources";
            script.Init(-17, 9, -11, 14);
        }
        ran = Random.Range(0, 3);
        if (ran < 2)
        {
            GameObject obj = Instantiate(r2);
            ruin1 script = obj.GetComponent<ruin1>();
            obj.tag = "resources";
            script.Init(-17, 9, -11, 14);
        }
        ran = Random.Range(0, 3);
        if (ran < 2)
        {
            GameObject obj = Instantiate(r3);
            ruin1 script = obj.GetComponent<ruin1>();
            obj.tag = "resources";
            script.Init(-17, 9, -11, 14);
        }
        ran = Random.Range(0, 3);
        if (ran < 2)
        {
            GameObject obj = Instantiate(r4);
            ruin1 script = obj.GetComponent<ruin1>();
            obj.tag = "resources";
            script.Init(-17, 9, -11, 14);
        }

        yield return new WaitForSeconds(115f);
        GlobalData.cameraShakeTime = 300;
        yield return new WaitForSeconds(5f);

        guiNeed = true;//ºÚÆÁ
        yield return new WaitForSeconds(5f);
        //ÏÂÒ»ÂÖ
        //yield return new WaitUntil(() => GlobalData.videoEnd);
        loop++;
        guiNeed = false;
        LoopTimerController.instance.resetLoopAndTimer();
        StartCoroutine(EnterLoop());
    }
    void OnGUI()
    {
        if (guiNeed)
        {
            GUI.color = Color.black;
            GUI.DrawTexture(new Rect(new Vector2(0,0), new Vector2(2000, 2000)), rectTexture);
        }
    }
}