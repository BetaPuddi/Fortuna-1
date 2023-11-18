using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PowerupSystem
{
    public class PowerupContainer : MonoBehaviour
    {
        public string currentPowerup;

        [SerializeField]
        private GameObject ballProjectile;
        [SerializeField]
        private GameObject crystalTrap;

        private InputActions _controls;

        [SerializeField]
        private float speedBoostDuration;
        [SerializeField]
        private int speedBoostAmount = 100;

        private void Awake()
        {
            _controls = new InputActions();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_controls.ControllerPowerup.UsePowerup.triggered && currentPowerup != null)
            {
                switch (currentPowerup)
                {
                    case "Speed Boost":
                        SpeedBoost(speedBoostAmount, speedBoostDuration);
                        RemovePowerup();
                        StopCoroutine(SpeedBoostCoroutine(0,0));
                        break;
                    case "Ball Projectile":
                        FireBallProjectile();
                        RemovePowerup();
                        break;
                    case "Crystal Trap":
                        DropCrystals();
                        RemovePowerup();
                        break;
                }
            }
        }

        private void OnEnable()
        {
            _controls.Enable();
        }
        private void OnDisable()
        {
            _controls.Disable();
        }

        public void AddPowerup(string powerup)
        {
            currentPowerup = powerup;
        }

        public void RemovePowerup()
        {
            currentPowerup = null;
        }

        public void SpeedBoost(int boostAmount, float boostDuration)
        {
            StartCoroutine(SpeedBoostCoroutine(boostAmount, boostDuration));
        }

        private IEnumerator SpeedBoostCoroutine(int boostAmount, float boostDuration)
        {
            GetComponentInParent<CarController>().motorForce += boostAmount;
            yield return new WaitForSeconds(boostDuration);
            GetComponentInParent<CarController>().motorForce -= boostAmount;
        }

        private void FireBallProjectile()
        {
            var transform2 = transform;
            var transform1 = transform2.forward * 2 + (transform2.up + new Vector3(0f, 50f, 0f) * 2);
            var projectile = Instantiate(ballProjectile, transform1.normalized, Quaternion.identity);
            projectile.GetComponent<BallProjectile>().vehicleTransform = transform2;
            projectile.GetComponent<BallProjectile>().AddForce();
        }

        private void DropCrystals()
        {
            var transform2 = transform;
            var transform1 = transform2.forward * -2;
            var crystals = Instantiate(crystalTrap, transform1.normalized, Quaternion.identity);
            crystals.GetComponent<CrystalTrap>().vehicleTransform = transform2;
        }
    }
}
