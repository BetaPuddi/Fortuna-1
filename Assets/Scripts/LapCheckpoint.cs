using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCheckpoint : MonoBehaviour
{
    public int Index;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CartLap>())
        {
            CartLap cart = other.GetComponent<CartLap>();
            if(cart.Checkpoint==Index + 1 || cart.Checkpoint==Index - 1) 
            {
                cart.Checkpoint = Index;
                Debug.Log(Index);
            }
        }
    }
}
