using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Combustible_Ice : InteractiveObject
{
    // Start is called before the first frame update
    Sprite sprite;
    public void Init(int xstart, int xend, int ystart, int yend)
    {
        int i = 0;
        CellPosition = new Vector3Int(Random.Range(xstart, xend), Random.Range(ystart, yend), 0);
        if (GlobalData.arrayData[CellPosition.x + 500, CellPosition.y + 500] == null)
        {
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
    public override void ArriveBehavior(NavMovement ObjIn)
    {
        base.ArriveBehavior(ObjIn);
        ObjIn.animator.SetBool("build", true);
        Debug.Log("arrive");
        ObjIn.CanMove = false;
        StartCoroutine(Deng1Miao(ObjIn));
        return;
    }

    IEnumerator Deng1Miao(NavMovement ObjIn)
    {
        yield return new WaitForSeconds(3F);
        sprite = Resources.Load<Sprite>("ice2");
        GetComponent<SpriteRenderer>().sprite = sprite;
        yield return new WaitForSeconds(3F);
        sprite = Resources.Load<Sprite>("ice3");
        GetComponent<SpriteRenderer>().sprite = sprite;
        GlobalData.iceQuantity++;
        Debug.Log("当前可燃冰:" + GlobalData.iceQuantity);
        yield return new WaitForSeconds(4F);
        ObjIn.CanMove = true;
        ObjIn.animator.SetBool("build", false);
        GlobalData.iceQuantity++;
        Debug.Log("当前可燃冰:" + GlobalData.iceQuantity);

        Destroy(gameObject);
    }

}
