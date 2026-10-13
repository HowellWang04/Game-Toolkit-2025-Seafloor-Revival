using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ResourceBarUI : MonoBehaviour
{
    public static ResourceBarUI instance;

    [SerializeField] private TextMeshProUGUI techPointsText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI shellText;
    [SerializeField] private TextMeshProUGUI fuelText;
    [SerializeField] private TextMeshProUGUI glassText;

    void Awake()
    {
        instance = this;
    }

    public void uiUpdateResourceBarNum(string type, int value)
    {
        switch (type.ToLower())
        {
            case "techpoints":
                techPointsText.text = value.ToString();
                break;
            case "food":
                foodText.text = value.ToString();
                break;
            case "shell":
                shellText.text = value.ToString();
                break;
            case "fuel":
                fuelText.text = value.ToString();
                break;
            case "glass":
                glassText.text = value.ToString();
                break;
            default:
                Debug.LogWarning("Unknown resource type: " + type);
                break;
        }
    }
    public void NumUpdate()
    {
            techPointsText.text = GlobalData.techQuantity.ToString();
            foodText.text = GlobalData.foodQuantity.ToString();
            shellText.text = GlobalData.shellQuantity.ToString();
            fuelText.text = GlobalData.iceQuantity.ToString();
            glassText.text = GlobalData.glassQuantity.ToString();
        }
}
