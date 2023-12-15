using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapHandle : MonoBehaviour
{
    public int CheckpointNumber;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CartLap>())
        {
            CartLap cart = other.GetComponent<CartLap>();   
            if(cart.Checkpoint == CheckpointNumber)
            {
                //kart has reached final cp
                //reset and finish lap
                cart.Checkpoint = 0;
                cart.lapNumber++;
                Debug.Log(cart.lapNumber);
            }
        }
    }
}
