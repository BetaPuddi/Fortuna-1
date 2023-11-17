using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    void Start()
    {
        DontDestroyOnLoad(this);
        UpdateAudioMixer();
    }

    
    public void UpdateAudioMixer()
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(PersistentData.persistentData.getVolume()) * 20);
    }
}
