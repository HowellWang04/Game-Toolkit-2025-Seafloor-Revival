using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sheltter : InteractiveObject
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
        Destroy(ObjIn.gameObject);
        GlobalData.populationSaved++;
        Debug.Log("saved");
        return;
    }
}
