using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Cluster : InteractiveObject
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
        ObjIn.animator.SetBool("build", true);
        Debug.Log("arrive");
        ObjIn.CanMove = false;
        StartCoroutine(Deng1Miao(ObjIn));
        return;
    }

    IEnumerator Deng1Miao(NavMovement ObjIn)
    {
        yield return new WaitForSeconds(3F);
        sprite = Resources.Load<Sprite>("shell2");
        GetComponent<SpriteRenderer>().sprite = sprite;
        yield return new WaitForSeconds(3F);
        sprite = Resources.Load<Sprite>("shell3");
        GetComponent<SpriteRenderer>().sprite = sprite;
        GlobalData.shellQuantity++;
        Debug.Log("当前贝壳:" + GlobalData.shellQuantity);
        yield return new WaitForSeconds(4F);
        ObjIn.CanMove = true;
        ObjIn.animator.SetBool("build", false);
        GlobalData.shellQuantity++;
        Debug.Log("当前贝壳:" + GlobalData.shellQuantity);

        Destroy(gameObject);
    }

}
