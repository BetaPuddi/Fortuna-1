using PowerupSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaceSetup : MonoBehaviour
{
    [SerializeField] GameObject raceStartCountdown;
    public bool carsSetUp = false;
    [SerializeField] GameObject mainCamera;
    GameObject positionTracker;

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
        positionTracker = GameObject.Find("PositionTracker");
        SpawnRacers();
    }

    //Spawn the racers in the correct positions. Make sure that the player is their chosen character.
    void SpawnRacers()
    {
        GameObject car;
        car = Instantiate(PersistentData.persistentData.getCharacter().characterModelPlayer, characterStartPositions[5], new Quaternion());
        car.GetComponent<CarController>().character = PersistentData.persistentData.getCharacter();
        car.GetComponent<CarController>().enabled = false;
        car.tag = "Player";
        positionTracker.GetComponent<PositionTracker>().cars.Add(car);
        //GameObject camera = Instantiate(mainCamera, car.transform, false);
        //camera.transform.localPosition = new Vector3(0, 3, -7);
        for (int x = 0, characterNumber = 0; x < characterStartPositions.Length-1; x++, characterNumber++)
        {
            if (possibleCharacters[characterNumber].characterName == PersistentData.persistentData.getCharacter().characterName) 
            { 
                characterNumber++;
            }
            car = Instantiate(possibleCharacters[characterNumber].characterModelAI, characterStartPositions[x], new Quaternion());
            car.GetComponent<AICarDrive>().character = possibleCharacters[characterNumber];
            car.GetComponent<AICarDrive>().SetWaypoints(routes[possibleCharacters[characterNumber].prefferedAITrackRoute].route);
            car.GetComponent<AICarDrive>().enabled = false;
            car.tag = "AICar";
            positionTracker.GetComponent<PositionTracker>().cars.Add(car);
        }

        Countdown();

        foreach (GameObject racer in positionTracker.GetComponent<PositionTracker>().cars)
        {
            if (racer.GetComponent<AICarDrive>() != null)
            {
                racer.GetComponent<AICarDrive>().enabled = true;
            }
            else
            {
                racer.GetComponent<CarController>().enabled = true;
            }
        }
        carsSetUp = true;
    }

    void Countdown()
    {
        StartCoroutine(CountdownCoroutine());

    }

    IEnumerator CountdownCoroutine()
    {
        //Display 5
        yield return new WaitForSeconds(1);
        //Display 4
        yield return new WaitForSeconds(1);
        //Display 3
        yield return new WaitForSeconds(1);
        //Display 2
        yield return new WaitForSeconds(1);
        //Display 1
        yield return new WaitForSeconds(1);
        //Display 0
        yield return new WaitForSeconds(1);
        //Allow cars to move
    }
}
