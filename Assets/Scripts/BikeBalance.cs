using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BikeBalance : MonoBehaviour
{
    float  tiltAngle;
    [SerializeField] float maxAngle;

    void Start()
    {
        tiltAngle = 0;
    }

    
    void Update()
    {
        tiltAngle = Mathf.Clamp(transform.rotation.eulerAngles.z, -maxAngle, maxAngle);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, tiltAngle);
    }
}
