using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TechPanelUIController : MonoBehaviour
{
    public static TechPanelUIController instance;
    [SerializeField] private TextMeshProUGUI shelterNumText;


    void Awake()
    {
        instance = this;
    }

    public void uiUpdateShelterNum(int num)
    {
        shelterNumText.text =  $"Shelter({num}/100)";
    }

}