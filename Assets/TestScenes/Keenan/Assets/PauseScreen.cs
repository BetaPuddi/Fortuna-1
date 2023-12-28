using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    bool paused;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseScreen;

    //all input action stuff
    private InputActionAsset inputActionAsset;

    void Start()
    {
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
        SceneManager.LoadScene(0);
    }
    
    public void ReplayButton()
    {
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reloads the scene
    }

    public void OnPause()
    {
        paused = !paused;
    }
}
