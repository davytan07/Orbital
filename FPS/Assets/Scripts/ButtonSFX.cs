using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    [SerializeField] AudioSource ButtonSound;

    public void ClickButtonSound()
    {
        ButtonSound.Play();
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f); // Wait for 0.2 seconds
    }
}
