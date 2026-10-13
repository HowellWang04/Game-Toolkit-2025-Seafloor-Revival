using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ruin1 : InteractiveObject
{

    // Start is called before the first frame update
    Sprite sprite;
    public void Init(int xstart, int xend, int ystart, int yend)
    {
        int i = 0;
        CellPosition = new Vector3Int(Random.Range(xstart, xend), Random.Range(ystart, yend), 0);
        if (GlobalData.arrayData[CellPosition.x + 500, CellPosition.y + 500] == null) {
            GlobalData.arrayData[CellPosition.x + 500, CellPosition.y + 500] = this;
            return;
        }
        else
        {

            Debug.Log("Des");
            Destroy(gameObject);
            return;
        }
    }
    public override void Start()
    {
        base.Start();
    }
    public override void TouchBehavior(NavMovement ObjIn)
    {
        base.TouchBehavior(ObjIn);

        return;
    }
    public override void GotoBehavior(NavMovement ObjIn)
    {
        base.GotoBehavior(ObjIn);
        Debug.Log("beginToMove");
        return;
    }
    public override void ArriveBehavior(NavMovement ObjIn)
    {
        base.ArriveBehavior(ObjIn);
        ObjIn.sr.enabled = false;
        ObjIn.CanMove = false;
        StartCoroutine(Deng1Miao(ObjIn));
        return;
    }

    IEnumerator Deng1Miao(NavMovement ObjIn)
    {
        int i = 5,ran=Random.Range(1,100);
        ran = Random.Range(1,100);
        bool des=true;
        while (i-->0)
        {
            ran = Random.Range(1, 100);
            yield return new WaitForSeconds(2F);
            if (ran < 5)
            {
                ObjIn.sr.enabled = true;
                ObjIn.animator.SetBool("death", true);
                yield return new WaitForSeconds(0.7f);
                Destroy(ObjIn.gameObject);
                des = false;
                break;
            }else if (ran < 20)
            {
                GlobalData.glassQuantity++;
            }
            else if (ran < 40)
            {
                GlobalData.foodQuantity++;
            }
            else if (ran < 60)
            {
                GlobalData.shellQuantity++;
            }
            else if (ran < 80)
            {
                GlobalData.iceQuantity++;
            }
        }
        ObjIn.sr.enabled = true;
        ObjIn.CanMove = true;
        if(des) Destroy(gameObject);
    }

}
