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
    [SerializeField] Slider SFXVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider vibrationSlider;


    

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
        Debug.Log(volumeSlider.value = PersistentData.persistentData.getMasterVolume());
        Debug.Log(SFXVolumeSlider.value = PersistentData.persistentData.getSFXVolume());
        Debug.Log(musicVolumeSlider.value = PersistentData.persistentData.getMusicVolume());
        Debug.Log(vibrationSlider.value = PersistentData.persistentData.getSensitivity());
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
        PersistentData.persistentData.setVibration(vibrationSlider.value);
        PersistentData.persistentData.setMasterVolume(volumeSlider.value);
        PersistentData.persistentData.setSFXVolume(SFXVolumeSlider.value);
        PersistentData.persistentData.setMusicVolume(musicVolumeSlider.value);
        PersistentData.persistentData.savePlayerPrefs();
    }

    public void SettingsResetButtonOnClick()
    {
        Debug.Log("Resetting progress");
        PersistentData.persistentData.resetCharacterLockProgress();
        PersistentData.persistentData.saveCharacterLockState();
    }
}
