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

    int volume;
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

    public void setVolume(int volumeIn)
    {
        volume = Mathf.Clamp(volumeIn, 0, 100);
        //GameObject.FindObjectOfType<AudioMixer>().SetFloat("Master", volume);
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
        PlayerPrefs.SetInt("Volume", volume);
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        PlayerPrefs.Save();
    }

    public void loadPlayerPrefs()
    {
        volume = PlayerPrefs.GetInt("Volume");
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
    }
}
