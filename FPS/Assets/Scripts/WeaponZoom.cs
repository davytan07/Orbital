using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpscamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToggle = false;
    PlayerLook playerLook;
    public float zoomInSensitivity = 50f;
    public float zoomOutSensitivity = 100f;

    private void Start()
    {
        playerLook = GetComponent<PlayerLook>();
    }

    public void ProcessZoom()
    {
       
        if (zoomedInToggle == false)
        {
            zoomedInToggle = true;
            fpscamera.fieldOfView = zoomedInFOV;
            playerLook.xSensitivity = zoomInSensitivity;
            playerLook.ySensitivity = zoomInSensitivity;
        }
        else
        {
            zoomedInToggle = false;
            fpscamera.fieldOfView = zoomedOutFOV;
            playerLook.xSensitivity = zoomOutSensitivity;
            playerLook.ySensitivity = zoomOutSensitivity;
        }
        
    }
}
