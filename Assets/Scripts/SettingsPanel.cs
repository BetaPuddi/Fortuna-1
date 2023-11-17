using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sensitivitySlider;


    

    public void SettingsButtonOnClick()
    {
        Debug.Log("Opening settings");
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        UpdateSliders();
    }

    private void UpdateSliders() 
    {
        PersistentData.persistentData.loadPlayerPrefs();
        Debug.Log("Updating sliders");
        Debug.Log(volumeSlider.value = PersistentData.persistentData.getVolume());
        Debug.Log(sensitivitySlider.value = PersistentData.persistentData.getSensitivity());
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
        PersistentData.persistentData.setSensitivity(sensitivitySlider.value);
        PersistentData.persistentData.setVolume(volumeSlider.value);
        PersistentData.persistentData.savePlayerPrefs();
    }
}
