using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    [Range(0, 100)] public float xSensitivity = 100f;
    [Range(0, 100)] public float ySensitivity = 100f;
    private float minClamp = -80f;
    private float maxClamp = 80f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //calculate camera roation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, minClamp, maxClamp);
        //apply to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //rotate player to look left or right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
