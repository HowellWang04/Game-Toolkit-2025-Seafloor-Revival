using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public bool destroyed;
    public Grid _grid;
    public Vector3Int CellPosition;
    public virtual void Start()
    {
        _grid = FindObjectOfType<Grid>();
        Application.targetFrameRate = 60;
        Debug.Log("Start");
    }

    void Update()
    {
        PositionUpdate();
    }
    public virtual void PositionUpdate()
    {
        GlobalData.arrayData[CellPosition.x + 500, CellPosition.y + 500] = this;
        transform.position = _grid.CellToWorld(CellPosition);
    }
    public virtual void TouchBehavior(NavMovement ObjIn)
    {

    }
    public virtual void GotoBehavior(NavMovement ObjIn)
    {
    }
    public virtual void ArriveBehavior(NavMovement ObjIn)
    {

    }
}
