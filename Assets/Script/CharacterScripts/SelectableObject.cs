using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SelectableObject : MonoBehaviour
{
    float height, width;
    public bool selected = false;
    bool selecting=false;
    Vector3 screenPosition, worldPosition;
    Vector2 start, end;
    private Texture2D rectTexture;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        height=100; 
        width=100;
        rectTexture = new Texture2D(1, 1);
        rectTexture.SetPixel(0, 0, new Color(1F, 1F, 1F, 0.25F));
        rectTexture.Apply();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("selected");
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
                selected = false;
            start =Input.mousePosition;
            GlobalData.noOneSelected = true;
        }
        if (Input.GetMouseButton(0))
        {
            selecting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            selecting = false;

        }
        end = Input.mousePosition;
        if (selecting)
        {
            if (Mathf.Max(start.x, end.x) > screenPosition.x - width / 2 && Mathf.Max(start.y, end.y) > screenPosition.y - height / 2 && Mathf.Min(start.x, end.x) < screenPosition.x + width / 2 && Mathf.Min(start.y, end.y) < screenPosition.y + height / 2)
            {
                if(GlobalData.noOneSelected)
                {

                    selected = true;
                    GlobalData.noOneSelected = false;
                }

            }
            //Debug.Log("Selecting");
            //selecting = false;
        }
        //else Debug.Log("not selecting");
        if (selected)
        {
            //Debug.Log("selected");
            //transform.position = new Vector3(transform.position.x, transform.position.y + 0.1F, transform.position.z);
            //selected = false;
        }
    }
    void OnGUI()
    {
        if (selected)
        {
            GUI.color = Color.white;
            GUI.DrawTexture(new Rect(screenPosition.x- width/2, Screen.height- screenPosition.y- height/2, width, height), rectTexture);
        }
    }
}
