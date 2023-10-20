using UnityEngine;
using UnityEngine.Serialization;

namespace PowerupSystem
{
    public abstract class Powerup : ScriptableObject
    {
        public string powerupName;
        public Texture2D powerupIcon;

        public abstract void PowerupEffect();
    }
}
