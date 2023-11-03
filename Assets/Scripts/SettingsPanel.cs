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


    

    public void SettingsButtonOnClick()
    {
        Debug.Log("Opening settings");
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        PersistentData.persistentData.loadPlayerPrefs();
        settingsPanel.GetComponentsInChildren<Slider>()[0].value = PersistentData.persistentData.getVolume();
        settingsPanel.GetComponentsInChildren<Slider>()[1].value = PersistentData.persistentData.getSensitivity();
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
        //audioMixer.SetFloat("volume", settingsPanel.GetComponentsInChildren<Slider>()[0].value);
        PersistentData.persistentData.setSensitivity(settingsPanel.GetComponentsInChildren<Slider>()[1].value);
        PersistentData.persistentData.setVolume(settingsPanel.GetComponentsInChildren<Slider>()[0].value);
        PersistentData.persistentData.savePlayerPrefs();
    }
}
