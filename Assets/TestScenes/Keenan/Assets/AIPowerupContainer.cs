using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerupSystem
{
    public class AIPowerupContainer : PowerupContainer
    {
        
        private void Update()
        {
            //Use powerup if the powerup is available
            if (!string.IsNullOrEmpty(currentPowerup))
            {
                Powerup();
                currentPowerup = "";
            }
        }

    }
}