using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace PowerupSystem
{
    public class PowerupBox : MonoBehaviour
    {
        private Collider _collider;
        public string[] powerupsToChooseFrom;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                this.GetComponent<MeshRenderer>().enabled = false;
                this.GetComponent<Collider>().enabled = false;
                AddPowerupToCharacter(ChooseRandomPowerup(), other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                this.GetComponent<MeshRenderer>().enabled = true;
                this.GetComponent<Collider>().enabled = true;
            }
        }

        private void AddPowerupToCharacter(string powerup, Collider other)
        {
            other.GetComponentInParent<PowerupContainer>().AddPowerup(powerup);
        }

        private string ChooseRandomPowerup()
        {
            int powerupNumber = Random.Range(0, powerupsToChooseFrom.Length);
            return powerupsToChooseFrom[powerupNumber];
        }
    }
}
