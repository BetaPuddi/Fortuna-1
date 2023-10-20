using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PowerupSystem
{
    [CreateAssetMenu(fileName = "Speed Boost", menuName = "Powerups/Speed Boost", order = 0)]
    public class SpeedBoostPowerup : Powerup
    {
        public float speedBoostAmount;

        public override void PowerupEffect()
        {

        }
    }
}
