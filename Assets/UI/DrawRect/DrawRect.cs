using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class DrawRect : MonoBehaviour
{
    Vector2 start, end;
    bool guiNeed=false;
    private Texture2D rectTexture;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rectTexture = new Texture2D(1, 1);
        rectTexture.SetPixel(0, 0, new Color(1F, 1F, 1F, 0.25F));
        rectTexture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = new Vector2(Input.mousePosition.x, Screen.height-Input.mousePosition.y);
            guiNeed = true;
        }
        end = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        
        

        if (Input.GetMouseButtonUp(0))
        {
            guiNeed = false;
        }
    }
    void OnGUI() {
        if (guiNeed) {
            GUI.color = Color.white;
            GUI.DrawTexture(new Rect(start, end-start),rectTexture);
        }
    }
}
