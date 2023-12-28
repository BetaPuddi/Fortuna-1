using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    bool paused;
    GameObject player;
    [SerializeField] GameObject pauseScreen;
    GameObject defaultSelectedButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] EventSystem eventSystem;

    //all input action stuff
    private InputActionAsset inputActionAsset;

    void Start()
    {
        defaultSelectedButton = eventSystem.firstSelectedGameObject;
        paused = false;
        Time.timeScale = 1.0f;
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        pauseScreen.SetActive(paused);
        Time.timeScale = paused ? 0:1;
    }

    public void MainMenuButton()
    {
        paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    public void RestartButton()
    {
        paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the scene
    }

    public void OnPause()
    {
        paused = !paused;
        eventSystem.SetSelectedGameObject(paused ? restartButton : defaultSelectedButton);
    }
}
