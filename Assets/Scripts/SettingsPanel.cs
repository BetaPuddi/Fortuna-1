using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public AudioMixer audioMixer;

    
    float sensitivity;

    public void SettingsButtonOnClick()
    {
        Debug.Log("Opening settings");
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void SettingsExitButtonOnClick()
    {
        Debug.Log("Closing settings");
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void SettingsSaveButtonOnClick()
    {
        Debug.Log("Saving settings");
        audioMixer.SetFloat("volume", settingsPanel.GetComponentsInChildren<Slider>()[0].value);
        sensitivity = settingsPanel.GetComponentsInChildren<Slider>()[1].value;
    }
}
