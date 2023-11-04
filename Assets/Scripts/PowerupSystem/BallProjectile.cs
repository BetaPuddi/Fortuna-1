using UnityEngine;

namespace PowerupSystem
{
    public class BallProjectile : MonoBehaviour
    {
        [SerializeField] private float projectileSpeed;
        void Start()
        {
            GetComponent<Rigidbody>().AddRelativeForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        }
    }
}
