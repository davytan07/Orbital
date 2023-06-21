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
            playerLook.xSensitivity /= 3;
            playerLook.ySensitivity /= 3;
        }
        else
        {
            zoomedInToggle = false;
            fpscamera.fieldOfView = zoomedOutFOV;
            playerLook.xSensitivity *= 3;
            playerLook.ySensitivity *= 3;
        }        
    }
}
