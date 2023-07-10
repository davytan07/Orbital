using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer BGMMixer;
    public AudioMixer SFXMixer;
    [SerializeField] PlayerLook playerLook;
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider sensSlider;

    private void Update() {
        // Debug.Log(playerLook.xSensitivity);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetMusicVolume(float volume)
    {
        Debug.Log("music volume " + volume);
        BGMMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        Debug.Log("sfx volume " + volume);
        SFXMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
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
        musicSlider.value = 1f;
        SFXSlider.value = 1f;
        sensSlider.value = 50f;
    }
}
