using UnityEngine;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        private AudioClip _audioClip;

        public AudioSource[] sfxAudioSources;

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
            foreach (var audioSource in sfxAudioSources)
            {
                if (audioSource.name == audioSourceName)
                {
                    _audioClip = audioSource.clip;
                    audioSource.PlayOneShot(_audioClip, 1f);
                    Debug.Log(audioSourceName);
                    Debug.Log(audioSource.clip);
                }
            }
        }

        public void PlayMusicAudioClip(string audioSourceName)
        {
            foreach (var audioSource in musicAudioSources)
            {
                if (audioSource.name == audioSourceName)
                {
                    //audioSource.clip = audioClip;
                    audioSource.Play();
                }
            }
        }
    }
}
