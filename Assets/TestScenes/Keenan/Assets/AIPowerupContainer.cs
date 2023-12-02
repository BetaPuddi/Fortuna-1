using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerupSystem
{
    public class AIPowerupContainer : PowerupContainer
    {
        float timer;
        float delay = 1;
        void Start()
        {
            timer = Time.time;
        }

        private void Update()
        {
            //Use powerup if the powerup is available
            if (currentPowerup != null && timer + delay > Time.time)
            {
                Powerup();
                timer = Time.time;
            }
        }

    }
}