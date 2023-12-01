using UnityEngine;

namespace AudioSystem
{
    public class EngineAudio : MonoBehaviour
    {
        public Rigidbody vehicleRigidbody;
        public AudioSource engineAudioSource;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            engineAudioSource.pitch = 0.6f + vehicleRigidbody.velocity.magnitude / 100;
        }
    }
}
