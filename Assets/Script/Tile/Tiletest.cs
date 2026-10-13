using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Tiletest : MonoBehaviour
{
    public static Tiletest Instance;
    public Grid gridIn;
    void Awake()
    {
        Instance = this;
    }
    public Vector3Int worldtocell(Vector3 _In)
    {
        Vector3Int ret= gridIn.WorldToCell(_In);
        return new Vector3Int(ret.x, ret.y, 0);
    }
    public Vector3Int GetMouseCell()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 1;
        Vector3 world = Camera.main.ScreenToWorldPoint(mouse);
        Vector3Int cell = gridIn.WorldToCell(world);
        cell.z = 0;
        return cell;
    }
}