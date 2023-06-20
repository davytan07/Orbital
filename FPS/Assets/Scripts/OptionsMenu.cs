using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer BGMMixer;
    [SerializeField] PlayerLook playerLook;
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sensSlider;

    private void Update() {
        Debug.Log(playerLook.xSensitivity);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume(float volume)
    {
        BGMMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMouseSensitivity(float sens)
    {
        playerLook.xSensitivity = sens;
        playerLook.ySensitivity = sens;
    }

    public void ResetDefaultSettings()
    {
        Debug.Log("resetted");
        fullscreenToggle.enabled = true;
        volumeSlider.value = 0.75f;
        sensSlider.value = 50f;
    }
}
