using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBarUI : MonoBehaviour
{
    [SerializeField] private List<BuildingSlotPrefab> slots;

    public static InventoryBarUI instance;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
    }

    // Update nth slot
    public void setSlot(int index, Sprite icon, int amount)
    {
        if (index >= 0 && index < slots.Count)
        {
            slots[index].setBuilding(icon, amount);
        }
    }

    public void cclearAll()
    {
        foreach (var slot in slots)
        {
            slot.clearBuildingIcon();
        }
    }
}
