using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class spr_cameraMovement : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
    Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x ,transform.position.y + 0.1F, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 0.1F, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x , transform.position.y - 0.1F, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 0.1F, transform.position.y, transform.position.z);
        }
        if (GlobalData.cameraShakeTime > 0)
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-0.15f,0.15f), transform.position.y + Random.Range(-0.15f, 0.15f), transform.position.z);
            GlobalData.cameraShakeTime--;
        }
    }
}
