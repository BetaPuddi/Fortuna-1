using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterInfo : ScriptableObject
{
    public string characterName;
    public Sprite characterThumbnail;
    public int mass;
    public float motorForce;
    public float breakForce;
    public float maxSteerAngle;
    public GameObject characterModel;
    public int prefferedAITrackRoute;
}
