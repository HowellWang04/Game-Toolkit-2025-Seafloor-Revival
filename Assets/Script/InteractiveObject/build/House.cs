using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class House : InteractiveObject
{
    public GameObject populationPrefab;
    // Start is called before the first frame update
    private void Start()
    {
        GlobalData.arrayData[CellPosition.x + 500, CellPosition.y + 500] = this;
    }
    public override void ArriveBehavior(NavMovement ObjIn)
    {
        base.ArriveBehavior(ObjIn);
        if (GlobalData.foodQuantity < 5)
        {
            Debug.Log("数量不足");
            return;
        }
        GlobalData.foodQuantity -= 5;
        ObjIn.sr.enabled=false;
        Debug.Log("arrive");
        ObjIn.CanMove = false;
        StartCoroutine(Deng1Miao(ObjIn));
        return;
    }

    IEnumerator Deng1Miao(NavMovement ObjIn)
    {
        yield return new WaitForSeconds(5F);

        ObjIn.CanMove = true;
        GlobalData.seahareQuantity+=1;
        Debug.Log("以生产人口:" + GlobalData.seahareQuantity);
        GameObject clone = Instantiate(populationPrefab, transform.position, Quaternion.identity);

        //生产人口代码

        ObjIn.sr.enabled = true;
    }
}
