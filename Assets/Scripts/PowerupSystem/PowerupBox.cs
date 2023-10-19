using UnityEngine;

namespace PowerupSystem
{
    public class PowerupBox : MonoBehaviour
    {
        private Collider _collider;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                this.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
