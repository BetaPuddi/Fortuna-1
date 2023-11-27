using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace PowerupSystem
{
    public class PowerupBox : MonoBehaviour
    {
        private Collider _collider;
        public string[] powerupsToChooseFrom;
        public int respawnTime = 10;
        private MeshRenderer _meshRenderer;
        private Collider _collider1;

        private void Start()
        {
            _collider1 = GetComponent<Collider>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("AICar"))
            {
                _meshRenderer.enabled = false;
                _collider1.enabled = false;
                AddPowerupToCharacter(ChooseRandomPowerup(), other);
                StartCoroutine(RespawnPowerupBox());
            }
        }

        private static void AddPowerupToCharacter(string powerup, Component other)
        {
            other.GetComponentInParent<PowerupContainer>().AddPowerup(powerup);
        }

        private string ChooseRandomPowerup()
        {
            var powerupNumber = Random.Range(0, powerupsToChooseFrom.Length);
            return powerupsToChooseFrom[powerupNumber];
        }

        IEnumerator RespawnPowerupBox()
        {
            yield return new WaitForSeconds(respawnTime);
            _meshRenderer.enabled = true;
            _collider1.enabled = true;
        }
    }
}
