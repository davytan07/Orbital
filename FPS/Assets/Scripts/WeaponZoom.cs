using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpscamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    PlayerLook playerLook;

    private void Start()
    {
        playerLook = GetComponent<PlayerLook>();
    }

    public void ProcessZoom(bool isKeyHeld)
    {
       
        if (isKeyHeld)
        {
            fpscamera.fieldOfView = zoomedInFOV;
            playerLook.xSensitivity /= 3;
            playerLook.ySensitivity /= 3;
        }
        else
        {
            fpscamera.fieldOfView = zoomedOutFOV;
            playerLook.xSensitivity *= 3;
            playerLook.ySensitivity *= 3;
        }        
    }
}
