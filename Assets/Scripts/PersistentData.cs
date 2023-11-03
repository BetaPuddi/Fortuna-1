using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData
{
    public static PersistentData persistentData {
        get;
        set;
    }

    float volume;
    float sensitivity;
    CharacterSelectObject characterSelectObject;

    [System.Serializable]
    public class CharacterSelectObject
    {
        public string name;
        public Sprite characterThumbnail;
    }

    public void setVolume(float volumeIn)
    {
        volume = Mathf.Clamp(volumeIn, 0, 100);
    }

    public void setSensitivity(float sensitivityIn)
    {
        sensitivity = Mathf.Clamp(sensitivityIn, 0, 100);
    }

    public void setCharacter(CharacterSelectObject characterIn)
    {
        characterSelectObject = characterIn;
    }

    public float getVolume()
    {
        return volume;
    }

    public float getSensitivity()
    {
        return sensitivity;
    }

    public CharacterSelectObject getCharacter()
    {
        return characterSelectObject;
    }

    


    public void savePlayerPrefs()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        PlayerPrefs.Save();
    }

    public void loadPlayerPrefs()
    {
        PlayerPrefs.GetFloat("Volume", 0);
        PlayerPrefs.GetFloat("Sensitivity", 0);
    }
}
