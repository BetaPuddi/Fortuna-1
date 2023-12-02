using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerupSystem
{
    public class AIPowerupContainer : PowerupContainer
    {
        
        void Start()
        {

        }

        private void Update()
        {
            //Use powerup if the powerup is available
            if (currentPowerup != null)
            {
                Powerup();
            }
        }

    }
}