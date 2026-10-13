using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarUI : MonoBehaviour
{
    public static BottomBarUI instance;
    [SerializeField] private TextMeshProUGUI seahareNumText;
    [SerializeField] private TextMeshProUGUI shelterPopulationText;


    void Awake()
    {
        instance = this;
    }

    public void uiUpdateSeahareNumText(int num)
    {
        seahareNumText.text = num.ToString();
    }
    
    public void uiUpdatShelterPopulationText(int population)
    {
        shelterPopulationText.text = population.ToString();
    }
}
