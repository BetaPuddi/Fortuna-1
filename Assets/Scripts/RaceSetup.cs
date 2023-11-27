using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceSetup : MonoBehaviour
{
    [SerializeField]
    CharacterInfo[] possibleCharacters;

    void Start()
    {
        SpawnRacers();
    }

    //Spawn the racers in the correct positions. Make sure that the player is their chosen character.
    void SpawnRacers()
    {
        int position = 0;
        for (int x = 1; x <= 3; x++)
        {
            for (int y = 1; y <= 2; y++)
            {
                if (x != 3 && y != 2)
                {
                    if (possibleCharacters[position].characterName == PersistentData.persistentData.getCharacter().characterName)
                    {
                        position++;
                    }
                    Instantiate(possibleCharacters[position]);
                }
                else
                {
                    //Spawn the player's vehicle
                    Instantiate(PersistentData.persistentData.getCharacter().characterModel);
                }
                position++;
            }
        }
    }
}
