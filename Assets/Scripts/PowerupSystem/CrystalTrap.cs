using System;
using UnityEngine;

namespace PowerupSystem
{
    public class CrystalTrap : MonoBehaviour
    {
        public int slowDownAmount = 400;
        public float slowDownDuration = 2;
        [SerializeField] private ParticleSystem crystalParticles;

        public Transform vehicleTransform;

        private void Start()
        {
            gameObject.transform.position = vehicleTransform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("AICar"))
            {
                other.GetComponent<PowerupContainer>().SpeedBoost(slowDownAmount, slowDownDuration);
                crystalParticles.Play();
                Destroy(gameObject);
            }
        }
    }
}
