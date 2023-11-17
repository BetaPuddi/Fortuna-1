using UnityEngine;

namespace PowerupSystem
{
    public class CrystalTrap : MonoBehaviour
    {
        public int slowDownAmount = 5;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PowerupContainer>().SpeedBoost(slowDownAmount);
                Destroy(gameObject);
            }
        }
    }
}
