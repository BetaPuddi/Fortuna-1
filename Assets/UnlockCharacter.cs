using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UnlockCharacter : MonoBehaviour
{

    GameObject player;
    CartLap _lapTracker;
    bool carUnlocked;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        _lapTracker = player.GetComponent<CartLap>();
        carUnlocked = false;
    }

    private void Update()
    {
        if (_lapTracker.lapNumber == 4 && !carUnlocked)
        {
            if (IsRaceWon())
            {
                UnlockNewCar();
                carUnlocked = true;
            }
        }
    }

    bool IsRaceWon()
    {
        return (player.GetComponent<CartLap>().Position == 1);
    }

    void UnlockNewCar()
    {
        int unlockedCars = PersistentData.persistentData.getCharactersLockProgress();
        int carNumber = ((int)math.log2(~unlockedCars & (unlockedCars + 1))) + 1;
        PersistentData.persistentData.setCharacterLockProgress(true, carNumber);
        PersistentData.persistentData.saveCharacterLockState();
    }
}
