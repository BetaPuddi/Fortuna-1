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

    float volume;
    float sensitivity;
    CharacterSelectObject characterSelectObject;
    

    [System.Serializable]
    public struct CharacterSelectObject
    {
        public string name;
        public Sprite characterThumbnail;
    }

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

    public void setVolume(float volumeIn)
    {
        volume = Mathf.Clamp(volumeIn, 0, 1f);
        GameObject.FindObjectOfType<AudioControl>().UpdateAudioMixer();
    }

    public void setSensitivity(float sensitivityIn)
    {
        sensitivity = Mathf.Clamp01(sensitivityIn);
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
        volume = PlayerPrefs.GetInt("Volume");
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
    }
}
