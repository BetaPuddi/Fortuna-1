using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowerupSystem
{
    public class BallProjectile : MonoBehaviour
    {
        [SerializeField] private float projectileSpeed;
        [SerializeField] private int projectileForceOnTarget;
        public Transform vehicleTransform;

        public void AddForce()
        {
            gameObject.transform.position = vehicleTransform.position + (vehicleTransform.up + new Vector3(0f, 1f, 0f));
            GetComponent<Rigidbody>().AddRelativeForce(vehicleTransform.forward * projectileSpeed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("AICar"))
            {
                var directions = new[] {new Vector3(-1, 0, 0), new Vector3(1, 0, 0)};
                var direction = directions[Random.Range(0, directions.Length)];
                other.GetComponentInParent<Rigidbody>()
                    .AddRelativeForce(transform.rotation * direction * projectileForceOnTarget, ForceMode.Impulse);
                Debug.Log(other.name);
                Destroy(gameObject);
            }
        }
    }
}
