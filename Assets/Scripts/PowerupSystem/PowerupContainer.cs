using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PowerupSystem
{
    public class PowerupContainer : MonoBehaviour
    {
        public string currentPowerup;
        public GameObject ballProjectile;

        public InputActions Controls;

        [SerializeField]
        private float speedBoostDuration;
        [SerializeField]
        private int speedBoostAmount = 100;

        private void Awake()
        {
            Controls = new InputActions();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Controls.ControllerPowerup.UsePowerup.triggered && currentPowerup != null)
            {
                switch (currentPowerup)
                {
                    case "Speed Boost":
                        SpeedBoost();
                        RemovePowerup();
                        StopCoroutine(SpeedBoostCoroutine());
                        break;
                    case "Ball Projectile":
                        FireBallProjectile();
                        RemovePowerup();
                        break;
                }
            }
        }

        private void OnEnable()
        {
            Controls.Enable();
        }
        private void OnDisable()
        {
            Controls.Disable();
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
            GetComponentInParent<CarController>().motorForce += speedBoostAmount;
            yield return new WaitForSeconds(speedBoostDuration);
            GetComponentInParent<CarController>().motorForce -= speedBoostAmount;
        }

        private void FireBallProjectile()
        {
            var transform2 = transform;
            var transform1 = transform2.forward * 2 + (transform2.up + new Vector3(0f, 50f, 0f) * 2);
            var projectile = Instantiate(ballProjectile, transform1.normalized, Quaternion.identity);
            projectile.GetComponent<BallProjectile>().vehicleTransform = transform2;
            projectile.GetComponent<BallProjectile>().AddForce();
        }
    }
}
