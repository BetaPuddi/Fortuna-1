using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void StartTheGame()
    {
        Debug.Log("Game Starting");
        SceneManager.LoadScene(2);
    }
}
