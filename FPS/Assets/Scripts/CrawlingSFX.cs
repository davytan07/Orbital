using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlingSFX : MonoBehaviour
{
    [SerializeField] AudioSource enemyCrawlSFX;
    
    public void playSound()
    {
        enemyCrawlSFX.Play();
    }
}
