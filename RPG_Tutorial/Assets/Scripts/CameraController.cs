using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //For the camera to follow
    public Transform traget;

    //For the camera offset
    public Vector3 offset;

    public float ZoomSpeed = 4f;

    public float minZoom = 5f;

    public float maxZoom = 15f;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    //For the camera zoom value
    private float currentZoom = 10f;

    private float currentYaw = 0f;
    
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    //Same as update but called right after
    void LateUpdate()
    {
        transform.position = traget.position - offset * currentZoom;
        transform.LookAt(traget.position + Vector3.up * pitch);

        transform.RotateAround(traget.position, Vector3.up, currentYaw);
    }
    
}
