using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CartLap))]
public class AICarDrive : MonoBehaviour
{
    private float steerAngle;
    private float currentBreakForce;
    private float currentAcceleratorLevel;

    [SerializeField] public float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform rearRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;

    private GameObject[] waypoints;

    private InputActionAsset inputActionAsset;

    public CharacterInfo character;
    private InputAction moveAction;
    private InputAction brakeAction;
    private InputAction gasAction;

    bool startFinished = false;

    //Get the wheels
    private IEnumerator Start()
    {
        while (GameObject.FindWithTag("RaceStart") != null && !GameObject.FindWithTag("RaceStart").GetComponent<RaceSetup>().carsSetUp)
        {
            yield return null;
        }
        

        motorForce = character.motorForce;
        breakForce = character.breakForce;
        maxSteerAngle = character.maxSteerAngle;
        startFinished = true;
        
        
    }

    private void FixedUpdate()
    {
        if (!startFinished) return;
        HandleNavigation();
        HandleMotor();
        HandleSteering();
        //UpdateWheels();
    }

    private void HandleNavigation()
    {
        Transform currentWaypointTransform = waypoints[GetComponent<CartLap>().Checkpoint + 1].transform;
        //Handles steering towards the next checkpoint
        Vector3 relativeWaypointTransform = transform.InverseTransformPoint(currentWaypointTransform.position);
        relativeWaypointTransform.y = 0;
        steerAngle = Vector3.SignedAngle(Vector3.forward, relativeWaypointTransform, Vector3.up);
        
        //Collision avoidance using raycasts
        int layerMask = ~(1 << 2);
        RaycastHit hit;
        int raycastLength = 5;
        Vector3 offset = transform.position + (transform.forward * 1.1f) + (transform.up * .25f);
        
        raycastLength = 3;
        if (Physics.Raycast(offset, Quaternion.AngleAxis(90, transform.up) * transform.forward, out hit, raycastLength, layerMask))
        {
            steerAngle -= 5f;
            //Debug.Log("90" + hit.collider.gameObject);
            //Debug.DrawRay(offset, Quaternion.AngleAxis(90, transform.up) * transform.forward * raycastLength, Color.red, 10);
        }
        if (Physics.Raycast(offset, Quaternion.AngleAxis(-90, transform.up) * transform.forward, out hit, raycastLength, layerMask))
        {
            steerAngle += 5f;
            //Debug.Log("-90" + hit.collider.gameObject);
            //Debug.DrawRay(offset, Quaternion.AngleAxis(-90, transform.up) * transform.forward * raycastLength, Color.red, 10);
        }

        bool bothAngledAheadRaycastHit = true;
        if (Physics.Raycast(offset, Quaternion.AngleAxis(45, transform.up) * transform.forward, out hit, raycastLength, layerMask))
        {
            steerAngle -= 20f;
            //Debug.Log("45" + hit.collider.gameObject);
            //Debug.DrawRay(offset, Quaternion.AngleAxis(45, transform.up) * transform.forward * raycastLength, Color.red, 10);
        }
        else
        {
            bothAngledAheadRaycastHit = false;
        }
        if (Physics.Raycast(offset, Quaternion.AngleAxis(-45, transform.up) * transform.forward, out hit, raycastLength, layerMask))
        {
            steerAngle += 20f;
            //Debug.Log("-45" + hit.collider.gameObject);
            //Debug.DrawRay(offset, Quaternion.AngleAxis(-45, transform.up) * transform.forward * raycastLength, Color.red, 10);
        }
        else
        {
            bothAngledAheadRaycastHit = false;
        }

        steerAngle = Mathf.Clamp(steerAngle, -maxSteerAngle, maxSteerAngle);

        float forwardSpeed = GetComponent<Rigidbody>().velocity.magnitude * Mathf.Sign(transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z);

        bool shouldSlowDown = (forwardSpeed >= 0 && Mathf.Sign(currentAcceleratorLevel) < 0) || forwardSpeed > 30 || (forwardSpeed > Mathf.Max(.5f, currentAcceleratorLevel) * 17.5f);
        bool shouldReverse;
        raycastLength = 20;
        //Modifies the accelerator level by the distance from raycast origin.
        bool frontHit = Physics.Raycast(offset, transform.forward, out hit, raycastLength + forwardSpeed, layerMask);
        if (!frontHit)
        { 
            currentAcceleratorLevel = 1;
        }
        else
        { 
            shouldReverse = frontHit&&(((raycastLength) + forwardSpeed) * .125f > hit.distance);
            
            Debug.DrawRay(offset, transform.forward* (raycastLength + forwardSpeed), Color.gray, .1f);
            Debug.DrawRay(offset, transform.forward* (raycastLength + forwardSpeed) * .125f, Color.black, .1f);
            if (hit.collider.gameObject != null) Debug.Log(hit.collider.gameObject);

        

            if (shouldReverse || bothAngledAheadRaycastHit)
            {
                currentAcceleratorLevel = -1;
                if (forwardSpeed <= 0)
                {
                    steerAngle = -steerAngle;
                    shouldSlowDown = false;
                }
                else
                {
                    shouldSlowDown = true;
                }
            }
            else
            {
                currentAcceleratorLevel = SigmoidLogisticFunction(Mathf.Clamp01(hit.distance - ((raycastLength + forwardSpeed) * .125f) / (raycastLength + forwardSpeed)), .5f, 2.5f, 1);
                shouldSlowDown = shouldSlowDown || (forwardSpeed >= hit.distance);
                

                float SigmoidLogisticFunction(float x, float mid, float k, float l)
                {
                    return l / (1 + Mathf.Exp(-k * (x-mid)));
                }

                if (bothAngledAheadRaycastHit)
                {
                    currentAcceleratorLevel /= 2;

                }
            }
        }

        //Calculate whether to break and cut off the motor if going too fast (too fast is either moving at > 30 speed, or moving faster than expected for the currentAcceleratorLevel).

        //if (shouldSlowDown)
        //{
        //    Debug.Log(this.name + " is breaking and is moving at " + forwardSpeed);
        //}
        currentBreakForce = shouldSlowDown ? breakForce : 0;
        currentAcceleratorLevel = shouldSlowDown ? 0 : currentAcceleratorLevel;
        

    }

    //Car move forward
    private void HandleMotor()
    {
        float motorTorque = motorForce * currentAcceleratorLevel;
        
        frontLeftWheelCollider.motorTorque = motorTorque;
        frontRightWheelCollider.motorTorque = motorTorque;

        ApplyBraking();
    }

    //Breaking
    private void ApplyBraking()
    {
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
    }

    //Car turn
    private void HandleSteering()
    {
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    //Make wheel meshes match wheel colliders
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    public void SetWaypoints(GameObject[] waypointsIn)
    {
        waypoints = waypointsIn;
    }
}
