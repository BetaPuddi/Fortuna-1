using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData persistentData {
        get;
        set;
    }

    public float volume;
    public float sensitivity;
    public CharacterSelectObject characterSelectObject;

    [System.Serializable]
    public class CharacterSelectObject
    {
        public string name;
        public Sprite characterThumbnail;
    }
}
