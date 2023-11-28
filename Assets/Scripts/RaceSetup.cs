using PowerupSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaceSetup : MonoBehaviour
{
    public bool carsSetUp = false;

    [Serializable]
    public class Route
    {
        public GameObject[] route;

        public Route(GameObject[] array)
        {
            route = array;
        }
    }

    [SerializeField] Route[] routes;
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
            car.GetComponent<AICarDrive>().SetWaypoints(routes[possibleCharacters[characterNumber].prefferedAITrackRoute].route);
            car.AddComponent<AIPowerupContainer>();
            car.tag = "AICar";
        }
        car = Instantiate(PersistentData.persistentData.getCharacter().characterModel, characterStartPositions[5], new Quaternion());
        car.AddComponent<CarController>();
        car.AddComponent<PowerupContainer>();
        car.tag = "Player";
        carsSetUp = true;
    }
}
