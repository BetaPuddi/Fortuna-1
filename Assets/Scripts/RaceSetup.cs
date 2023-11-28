using PowerupSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaceSetup : MonoBehaviour
{
    [SerializeField] CharacterInfo[] possibleCharacters;
    Vector3[] characterStartPositions = { new Vector3(-2.3f, 0, -2), new Vector3(2.3f, 0, -2), new Vector3(-2.3f, 0, -12), new Vector3(2.3f, 0, -12), new Vector3(-2.3f, 0, -22), new Vector3(2.3f, 0, -22) };

    void Start()
    {
        SpawnRacers();
    }

    //Spawn the racers in the correct positions. Make sure that the player is their chosen character.
    void SpawnRacers()
    {
        GameObject car;
        for (int x = 0, characterNumber = 0; x < characterStartPositions.Length-1; x++, characterNumber++)
        {
            if (possibleCharacters[characterNumber].characterModel == PersistentData.persistentData.getCharacter().GameObject()) 
            { 
                characterNumber++;
            }
            car = Instantiate(possibleCharacters[characterNumber].characterModel, characterStartPositions[x], new Quaternion());
            car.AddComponent<AICarDrive>();
            car.AddComponent<AIPowerupContainer>();
        }
        car = Instantiate(PersistentData.persistentData.getCharacter().GameObject(), characterStartPositions[5], new Quaternion());
        car.AddComponent<CarController>();
        car.AddComponent<PowerupContainer>();
    }
}
