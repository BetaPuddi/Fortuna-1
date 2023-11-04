using System.Collections;
using UnityEngine;

namespace PowerupSystem
{
    public class PowerupContainer : MonoBehaviour
    {
        public string currentPowerup;
        public GameObject ballProjectile;

        [SerializeField]
        private float speedBoostDuration;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && currentPowerup != null)
            {
                switch (currentPowerup)
                {
                    case "Speed Boost":
                        SpeedBoost();
                        RemovePowerup();
                        StopCoroutine(SpeedBoostCoroutine());
                        break;
                    case "Ball Projectile":
                        break;
                }
            }
        }

        public void AddPowerup(string powerup)
        {
            currentPowerup = powerup;
        }

        public void RemovePowerup()
        {
            currentPowerup = null;
        }

        public void SpeedBoost()
        {
            StartCoroutine(SpeedBoostCoroutine());
        }

        IEnumerator SpeedBoostCoroutine()
        {
            GetComponentInParent<CarController>().motorForce += 100;
            yield return new WaitForSeconds(speedBoostDuration);
            GetComponentInParent<CarController>().motorForce -= 100;
        }
    }
}
