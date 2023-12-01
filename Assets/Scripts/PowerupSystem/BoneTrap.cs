using System;
using UnityEngine;

namespace PowerupSystem
{
    public class BoneTrap : MonoBehaviour
    {
        public Transform vehicleTransform;

        private void Start()
        {
            gameObject.transform.position = vehicleTransform.position;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("AICar"))
            {
                Destroy(gameObject);
            }
        }

    }
}
