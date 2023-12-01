using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>(); // List of all cars including the player
    private Dictionary<GameObject, CartLap> cartLaps = new Dictionary<GameObject, CartLap>();
    private Dictionary<GameObject, DateTime> lastCheckpointTime = new Dictionary<GameObject, DateTime>();
    private Dictionary<GameObject, int> checkpointProgress = new Dictionary<GameObject, int>();

    // Update is called once per frame
    void Update()
    {
        UpdateCheckpointProgress();
        UpdatePositions();
    }

    void UpdateCheckpointProgress()
    {
        foreach (GameObject car in cars)
        {
            CartLap cartLap = car.GetComponent<CartLap>();
            if (cartLap != null)
            {
                cartLaps[car] = cartLap;

                // Update the checkpoint progress for the car
                int currentCheckpoint = cartLap.Checkpoint;
                checkpointProgress[car] = currentCheckpoint;

                // Update the time the car went through the checkpoint
                lastCheckpointTime[car] = DateTime.Now; // Update with your own time tracking logic
            }
        }
    }

    public int GetPositionForCar(GameObject car)
    {
        int position = 0;

        int currentCheckpoint = checkpointProgress[car];
        int currentLap = cartLaps[car].lapNumber;

        List<GameObject> sortedCars = cars.OrderBy(c =>
        {
            int carCheckpoint = checkpointProgress[c];
            int carLap = cartLaps[c].lapNumber;

            if (carLap == currentLap)
            {
                return carCheckpoint.CompareTo(currentCheckpoint);
            }
            return carLap.CompareTo(currentLap);
        }).ToList();

        for (int i = 0; i < sortedCars.Count; i++)
        {
            if (sortedCars[i] == car)
            {
                position = cars.Count - i; // Reversed position order to start from 1 for the first car
                break;
            }
        }

        return position;
    }




    void UpdatePositions()
    {
        foreach (GameObject car in cars)
        {
            int position = GetPositionForCar(car);
            Debug.Log(car.name + " is in position: " + position); //add to ai using "position" variable

            CartLap cartLap = car.GetComponent<CartLap>();
            if (cartLap != null)
            {
                cartLap.UpdatePosition(position); // Update the position in the CartLap script
            }
        }
    }
}
