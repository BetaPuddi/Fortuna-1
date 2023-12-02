using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace PowerupSystem
{
    public class PowerupContainer : MonoBehaviour
    {
        public string currentPowerup;

        [SerializeField]
        private GameObject ballProjectile, crystalTrap, boneTrap, frontSpawner, rearSpawner, firstPersonCamera, mainCamera, catnipPostProcessing;
        [SerializeField]
        private AudioSource ballAudioUse, crystalAudioUse, boneAudioUse, speedBoostAudioUse, catnipAudioUse, mindsEyeUse;
        [SerializeField]
        private TrailRenderer speedBoostTrail;

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
                        speedBoostAudioUse.Play();
                        RemovePowerup();
                        StopCoroutine(SpeedBoostCoroutine(0,0));
                        break;
                    case "Ball Projectile":
                        FireBallProjectile();
                        ballAudioUse.Play();
                        RemovePowerup();
                        break;
                    case "Crystal Trap":
                        DropCrystals();
                        crystalAudioUse.Play();
                        RemovePowerup();
                        break;
                    case "Bone Trap":
                        DropBones();
                        boneAudioUse.Play();
                        RemovePowerup();
                        break;
                    case "Mind's Eye":
                        StartCoroutine(MindsEyeCoroutine());
                        mindsEyeUse.Play();
                        RemovePowerup();
                        break;
                    case "Catnip":
                        StartCoroutine(CatnipCoroutine());
                        catnipAudioUse.Play();
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
            speedBoostTrail.enabled = true;
            if (GetComponentInParent<CarCharacter>() != null)
            { 
                GetComponentInParent<CarController>().motorForce += boostAmount;
                yield return new WaitForSeconds(boostDuration);
                GetComponentInParent<CarController>().motorForce -= boostAmount;
            }
            else if (GetComponentInParent<AICarDrive>() != null)
            {
                GetComponentInParent<AICarDrive>().motorForce += boostAmount;
                yield return new WaitForSeconds(boostDuration);
                GetComponentInParent<AICarDrive>().motorForce -= boostAmount;
            }
            speedBoostTrail.enabled = false;
        }

        private IEnumerator MindsEyeCoroutine()
        {
            if (mainCamera != null && firstPersonCamera != null) { 
                mainCamera.SetActive(false);
                firstPersonCamera.SetActive(true);
                yield return new WaitForSeconds(5);
                mainCamera.SetActive(true);
                firstPersonCamera.SetActive(false);
            }
        }

        private IEnumerator CatnipCoroutine()
        {
            if (catnipPostProcessing != null) { 
                catnipPostProcessing.SetActive(true);
                yield return new WaitForSeconds(5);
                catnipPostProcessing.SetActive(false);
            }
        }

        private void FireBallProjectile()
        {
            var transform2 = frontSpawner.transform;
            var transform1 = transform2.forward * 2 + (transform2.up + new Vector3(0f, 50f, 0f) * 2);
            var projectile = Instantiate(ballProjectile, transform1.normalized, Quaternion.identity);
            projectile.GetComponent<BallProjectile>().vehicleTransform = transform2;
            projectile.GetComponent<BallProjectile>().AddForce();
        }

        private void DropCrystals()
        {
            var transform2 = rearSpawner.transform;
            var transform1 = transform2.forward * -2;
            var crystals = Instantiate(crystalTrap, transform1.normalized, Quaternion.identity);
            crystals.GetComponent<CrystalTrap>().vehicleTransform = transform2;
        }

        private void DropBones()
        {
            var transform2 = rearSpawner.transform;
            var transform1 = transform2.forward * -2;
            var bones = Instantiate(boneTrap, transform1.normalized, Quaternion.identity);
            bones.GetComponent<BoneTrap>().vehicleTransform = transform2;
        }

        public void Powerup()
        {
            switch (currentPowerup)
            {
                case "Speed Boost":
                    SpeedBoost(speedBoostAmount, speedBoostDuration);
                    speedBoostAudioUse.Play();
                    RemovePowerup();
                    StopCoroutine(SpeedBoostCoroutine(0, 0));
                    break;
                case "Ball Projectile":
                    FireBallProjectile();
                    ballAudioUse.Play();
                    RemovePowerup();
                    break;
                case "Crystal Trap":
                    DropCrystals();
                    crystalAudioUse.Play();
                    RemovePowerup();
                    break;
                case "Bone Trap":
                    DropBones();
                    boneAudioUse.Play();
                    RemovePowerup();
                    break;
                case "Mind's Eye":
                    StartCoroutine(MindsEyeCoroutine());
                    mindsEyeUse.Play();
                    RemovePowerup();
                    break;
                case "Catnip":
                    StartCoroutine(CatnipCoroutine());
                    catnipAudioUse.Play();
                    RemovePowerup();
                    break;
            }
        }
    }
}
