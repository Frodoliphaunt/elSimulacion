using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private int zoomSpeed = 40;
    private float rotX;

    void LateUpdate()
    {
        transform.position += Input.GetAxis("Mouse ScrollWheel")  * zoomSpeed * transform.forward;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -122, -19), Mathf.Clamp(transform.position.y, 5, 60f), Mathf.Clamp(transform.position.z, -5, 0));      
        rotX += Input.GetAxis("Vertical") * -0.5f;
        rotX = Mathf.Clamp(rotX, 15f, 75f);
        transform.localRotation = Quaternion.Euler(rotX, 90f, 0f);
    }
}
