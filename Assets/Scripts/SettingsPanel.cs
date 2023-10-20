using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;

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
}
