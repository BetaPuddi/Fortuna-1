using UnityEngine;

namespace PowerupSystem
{
    public class BallProjectile : MonoBehaviour
    {
        [SerializeField] private float projectileSpeed;
        public Transform vehicleTransform;

        public void AddForce()
        {
            gameObject.transform.position = vehicleTransform.position;
            GetComponent<Rigidbody>().AddRelativeForce(vehicleTransform.forward * projectileSpeed, ForceMode.Impulse);
        }
    }
}
