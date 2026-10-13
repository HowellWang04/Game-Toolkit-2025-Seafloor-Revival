using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Workshop : InteractiveObject
{
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("set");
        GlobalData.arrayData[CellPosition.x + 500, CellPosition.y + 500] = this;
    }
    public override void ArriveBehavior(NavMovement ObjIn)
    {
        base.ArriveBehavior(ObjIn);
        if (GlobalData.glassQuantity < 5)
        {
            Debug.Log("数量不足");
            return;
        }
        GlobalData.glassQuantity -= 5;
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
        GlobalData.techQuantity+=1;
        Debug.Log("已生产科技:" + GlobalData.techQuantity);
        ObjIn.sr.enabled = true;
    }
}
