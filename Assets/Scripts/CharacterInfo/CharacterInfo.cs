using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterInfo : ScriptableObject
{
    public string characterName;
    public Sprite characterThumbnail;
    public int mass;
    public GameObject characterModel;
}
