using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seaweed_Farm : InteractiveObject
{
    // Start is called before the first frame update

    private void Start()
    {
        GlobalData.arrayData[CellPosition.x + 500, CellPosition.y + 500] = this;
    }
    public override void ArriveBehavior(NavMovement ObjIn)
    {
        base.ArriveBehavior(ObjIn);
        ObjIn.CanMove = false;
        Debug.Log("arrive");
        ObjIn.animator.SetBool("collect1",true);
        StartCoroutine(Deng1Miao(ObjIn));
        return;
    }

    IEnumerator Deng1Miao(NavMovement ObjIn)
    {
        yield return new WaitForSeconds(5F);
        ObjIn.CanMove = true;
        GlobalData.foodQuantity+=2;
        Debug.Log("已生产食物:" + GlobalData.foodQuantity);
        ObjIn.animator.SetBool("collect1", false);
        ResourceBarUI.instance. uiUpdateResourceBarNum("food", GlobalData.foodQuantity);
        //Destroy(gameObject);
    }
}
