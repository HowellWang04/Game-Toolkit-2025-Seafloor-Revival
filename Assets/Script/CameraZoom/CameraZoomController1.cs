using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    public Camera cam;
    public float zoomSpeed = 5f;
    public float smoothTime = 0.2f;

    private float targetSize;
    private float zoomVelocity;

    void Start()
    {
        targetSize = cam.orthographicSize;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            targetSize -= scroll * zoomSpeed;
            targetSize = Mathf.Clamp(targetSize, 2f, 20f);
        }

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetSize, ref zoomVelocity, smoothTime);
    }
}
