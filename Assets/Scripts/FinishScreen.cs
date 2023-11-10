using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScreen : MonoBehaviour
{
    public GameObject player;
    private CartLap _lapTracker;
    public GameObject endScreen;
    private void Start()
    {
        _lapTracker = player.GetComponent<CartLap>();
    }
    private void Update()
    {
        if (_lapTracker.lapNumber == 4)
        {
            endScreen.SetActive(true); 
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
