using System;
using UnityEngine;
using UnityEngine.Audio;

public class PersistentData
{
    private static PersistentData instance;

    public static PersistentData persistentData
    {
        get
        {
            if (instance == null)
            {
                instance = new PersistentData();
            }
            return instance;
        }

    }

    //The data to be stored
    float masterVolume;
    float SFXVolume;
    float musicVolume;
    float sensitivity;
    float vibrationIntensity;
    CharacterInfo characterSelectObject;
    int charactersLockProgress;
    TrackInfo trackSelectObject;
    

    [System.Serializable]
    public struct SaveData
    {

    }

    public void saveProgress()
    {

    }

    public void loadProgress()
    {

    }

    //Sets volume (Does not save it)
    public void setMasterVolume(float volumeIn)
    {
        masterVolume = Mathf.Clamp(volumeIn, 0, 1f);
        GameObject.FindObjectOfType<AudioControl>().UpdateAudioMixer();
    }

    public void setSFXVolume(float volumeIn)
    {
        SFXVolume = Mathf.Clamp(volumeIn, 0, 1f);
        GameObject.FindObjectOfType<AudioControl>().UpdateAudioMixer();
    }

    public void setMusicVolume(float volumeIn)
    {
        musicVolume = Mathf.Clamp(volumeIn, 0, 1f);
        GameObject.FindObjectOfType<AudioControl>().UpdateAudioMixer();
    }

    //Sets sensitivity (Does not save it)
    public void setSensitivity(float sensitivityIn)
    {
        sensitivity = Mathf.Clamp01(sensitivityIn);
    }

    public void setVibration(float vibrationIn)
    {
        vibrationIntensity = Mathf.Clamp01(vibrationIn);
    }

    //Sets the character
    public void setCharacter(CharacterInfo characterIn)
    {
        characterSelectObject = characterIn;
    }

    public void setCharacterLockProgress(bool lockState, int characterNumber)
    {
        charactersLockProgress = (charactersLockProgress & ~(1<<characterNumber-1)) | (Convert.ToInt32(lockState) << characterNumber - 1);
        setCharacterIntLockProgress(charactersLockProgress);
    }

    void setCharacterIntLockProgress(int lockIn)
    {
        charactersLockProgress = lockIn;
    }

    public void resetCharacterLockProgress()
    {
        charactersLockProgress = 1;
    }

    public void setTrack(TrackInfo trackIn)
    {
        trackSelectObject = trackIn;
    }

    //Returns the volume
    public float getMasterVolume()
    {
        return masterVolume;
    }

    public float getSFXVolume()
    {
        return SFXVolume;
    }

    public float getMusicVolume()
    {
        return musicVolume;
    }

    //Returns the sensitivity value
    public float getSensitivity()
    {
        return sensitivity;
    }

    public float getVibration()
    {
        return vibrationIntensity;
    }

    //Returns the character chosen in the character select menu
    public CharacterInfo getCharacter()
    {
        return characterSelectObject;
    }

    public int getCharactersLockProgress()
    {
        return charactersLockProgress;
    }

    public TrackInfo getTrack()
    {
        return trackSelectObject;
    }

    //Saves the current values of volume and sensitivity to player preferences
    public void savePlayerPrefs()
    {
        PlayerPrefs.SetFloat("Volume", masterVolume);
        PlayerPrefs.SetFloat("vibration", vibrationIntensity);
        PlayerPrefs.Save();
    }

    public void saveCharacterLockState()
    {
        PlayerPrefs.SetInt("CharactersLocked", charactersLockProgress);
    }

    //Loads the values of volume and sensitivity from player preferences
    public void loadPlayerPrefs()
    {
        masterVolume = PlayerPrefs.GetFloat("Volume", 1);
        vibrationIntensity = PlayerPrefs.GetFloat("vibration", 1);
        sensitivity = PlayerPrefs.GetFloat("Sensitivity", 1);
    }

    public void loadCharacterLockState()
    {
        charactersLockProgress = PlayerPrefs.GetInt("CharactersLocked", 1);

    }
}
