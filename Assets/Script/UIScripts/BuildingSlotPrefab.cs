using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingSlotPrefab : MonoBehaviour
{
    [SerializeField] private Image buildingIcon;
    [SerializeField] private TextMeshProUGUI slotQuantityText;

    public void setBuilding(Sprite sprite, int quantity)
    {
        buildingIcon.sprite = sprite;
        buildingIcon.enabled = true;
        slotQuantityText.text = quantity > 1 ? quantity.ToString() : "";
    }

    public void clearBuildingIcon()
    {
        buildingIcon.sprite = null;
        buildingIcon.enabled = false;
        slotQuantityText.text = "";
    }
}
