using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInvincibility : MonoBehaviour
{
    [SerializeField] private Canvas impactCanvas;
    void Start()
    {
        impactCanvas.enabled = false;
    }

    public void ShowInvincibility(float time)
    {
        StartCoroutine(ShowInvunerable(time));
    }

    IEnumerator ShowInvunerable(float time)
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(time);
        impactCanvas.enabled = false;
    }
}
