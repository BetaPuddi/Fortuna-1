using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    public Vector3 initialPosition;
    public Vector3 respawnRotation = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        initialPosition = transform.position;
        StartCoroutine(UpdateInitialPositionRoutine());
    }

    IEnumerator UpdateInitialPositionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            if (transform.position.y >= 0)
            {
                initialPosition = transform.position;
            }
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = initialPosition;
            transform.rotation = Quaternion.Euler(respawnRotation);
        }
    }
}
