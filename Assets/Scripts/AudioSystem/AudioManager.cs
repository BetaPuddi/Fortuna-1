using UnityEngine;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        public AudioSource[] carSfxAudioSources;
        public AudioSource[] uiSfxAudioSources;
        public AudioSource[] musicAudioSources;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void PlaySfxAudioClip(string audioSourceName)
        {
            foreach (var audioSource in carSfxAudioSources)
            {
                if (audioSource.name == audioSourceName)
                {
                    audioSource.PlayOneShot(audioSource.clip, 1f);
                }
            }
        }

        public void PlayUiSfxAudioClip(string audioSourceName)
        {
            foreach (var audioSource in uiSfxAudioSources)
            {
                if (audioSource.name == audioSourceName)
                {
                    audioSource.PlayOneShot(audioSource.clip, 1f);
                }
            }
        }

        public void PlayMusicAudioClip(string audioSourceName)
        {
            foreach (var audioSource in musicAudioSources)
            {
                if (audioSource.name == audioSourceName)
                {
                    audioSource.pitch = Random.Range(0.8f, 1.2f);
                    audioSource.Play();
                }
            }
        }
    }
}