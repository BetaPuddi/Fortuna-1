using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScreen : MonoBehaviour
{
    public GameObject player;
    private CartLap _lapTracker;
    public GameObject endScreen, winIcon, loseIcon;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        _lapTracker = player.GetComponent<CartLap>();
    }
    private void Update()
    {
        if (_lapTracker.lapNumber == 4)
        {
            endScreen.SetActive(true);
            switch (player.GetComponent<CartLap>().Position)
            {
                case 1:
                    winIcon.SetActive(true);
                    loseIcon.SetActive(false);
                    break;
                default:
                    loseIcon.SetActive(true);
                    winIcon.SetActive(false);
                    break;
            }
        }
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ReplayButton()
    {
        SceneManager.LoadScene(1);
    }
}
