using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScreen : MonoBehaviour
{
    public GameObject player;
    private CartLap lapTracker;
    public GameObject endScreen;
    private void Start()
    {
        lapTracker = player.GetComponent<CartLap>();
    }
    private void Update()
    {
        if (lapTracker.lapNumber == 4)
        {
            endScreen.SetActive(true); 
        }
    }
}
