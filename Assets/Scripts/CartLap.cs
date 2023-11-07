using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartLap : MonoBehaviour
{
    public int lapNumber;
    public int Checkpoint;
    private void Start()
    {
        lapNumber = 1;
        Checkpoint = 0;
    }
}
