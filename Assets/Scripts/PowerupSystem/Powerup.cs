using UnityEngine;

namespace PowerupSystem
{
    public abstract class Powerup
    {
        public string PowerupName;
        public Texture2D PowerupIcon;

        public abstract void PowerupEffect();
    }
}
