using System;
using UnityEngine;

namespace PowerupSystem
{
    public class CrystalTrap : MonoBehaviour
    {
        public int slowDownAmount = 400;
        public float slowDownDuration = 2;

        public Transform vehicleTransform;

        private void Start()
        {
            gameObject.transform.position = vehicleTransform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PowerupContainer>().SpeedBoost(slowDownAmount, slowDownDuration);
                Destroy(gameObject);
            }
        }
    }
}
