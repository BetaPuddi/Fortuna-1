using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public GameObject levelSelectPanel;
    public GameObject characterSelectPanel;
    public GameObject mainMenuPanel;

    public void PlayButtonOnClick()
    {
        characterSelectPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void LevelSelectBackButtonOnClick() { 
        levelSelectPanel.SetActive(false); 
        mainMenuPanel.SetActive(true);
    }
    
    public void CharacterSelectBackButtonOnClick() { 
        characterSelectPanel.SetActive(false); 
        mainMenuPanel.SetActive(true);
    }
}
