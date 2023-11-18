using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    private void LateUpdate()
    {
        Vector3 newpos = player.position;
        newpos.y = transform.position.y;
        transform.position = newpos;
    }
}
