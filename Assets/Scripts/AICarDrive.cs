using System.Collections;
using System.Collections.Generic;
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
        //Get the colliders
        Transform wheelColliders = transform.Find("Wheels").Find("Colliders");
        frontLeftWheelCollider = wheelColliders.Find("FrontLeftWheel").GetComponent<WheelCollider>();
        frontRightWheelCollider = wheelColliders.Find("FrontRightWheel").GetComponent<WheelCollider>();
        rearLeftWheelCollider = wheelColliders.Find("RearLeftWheel").GetComponent<WheelCollider>();
        rearRightWheelCollider = wheelColliders.Find("RearRightWheel").GetComponent<WheelCollider>();
        //Get the transforms
        Transform wheelTransforms = transform.Find("Wheels").Find("Meshes");
        frontLeftWheelTransform = wheelTransforms.Find("FrontLeftWheel");
        frontRightWheelTransform = wheelTransforms.Find("FrontRightWheel");
        rearLeftWheelTransform = wheelTransforms.Find("RearLeftWheel");
        rearRightWheelTransform = wheelTransforms.Find("RearRightWheel");

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
        UpdateWheels();
    }

    private void HandleNavigation()
    {
        Transform currentWaypointTransform = waypoints[(int)Mathf.Repeat(GetComponent<CartLap>().Checkpoint,48)].transform;
        //Handles steering towards the next checkpoint
        Vector3 relativeWaypointTransform = transform.InverseTransformPoint(currentWaypointTransform.position);
        relativeWaypointTransform.y = 0;
        steerAngle = Vector3.SignedAngle(Vector3.forward, relativeWaypointTransform, Vector3.up);
        
        //Collision avoidance using raycasts
        int layerMask = 1 << 0;
        RaycastHit hit;
        int raycastLength = 5;
        Vector3 offset = transform.position + (transform.forward * 2.3f) + (transform.up * .5f);
        if (Physics.Raycast(offset, Quaternion.AngleAxis(45, transform.up) * transform.forward, out hit, raycastLength, layerMask))
        {
            steerAngle -= 20f;
            //Debug.Log("45" + hit.collider.gameObject);
            //Debug.DrawRay(offset, Quaternion.AngleAxis(45, transform.up) * transform.forward * raycastLength, Color.red, 10);
        }
        if (Physics.Raycast(offset, Quaternion.AngleAxis(-45, transform.up) * transform.forward, out hit, raycastLength, layerMask))
        {
            steerAngle += 20f;
            //Debug.Log("-45" + hit.collider.gameObject);
            //Debug.DrawRay(offset, Quaternion.AngleAxis(-45, transform.up) * transform.forward * raycastLength, Color.red, 10);
        }
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
        
        steerAngle = Mathf.Clamp(steerAngle, -maxSteerAngle, maxSteerAngle);

        float forwardSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        raycastLength = 20;
        //Reverse if raycast detects an obstruction ahead
        if (Physics.Raycast(offset, transform.forward, out hit, (raycastLength / 8f), layerMask))
        {
            currentAcceleratorLevel = -1;
            steerAngle = 0;
            //Debug.Log(hit.collider.gameObject);
            Debug.DrawRay(offset, transform.forward * ((raycastLength / 8f)), Color.white, 1);
        }
        else if (Physics.Raycast(offset, transform.forward, out hit, (raycastLength / 4f), layerMask)) //Reduce speed if raycast detects an obstruction ahead
        {
            currentAcceleratorLevel = .1f;
            //Debug.Log(hit.collider.gameObject);
            Debug.DrawRay(offset, transform.forward * ((raycastLength /4f)), Color.black, 1);
        }
        else if (Physics.Raycast(offset, transform.forward, out hit, (raycastLength / 2f), layerMask))
        {
            currentAcceleratorLevel = .5f;
            //Debug.Log(hit.collider.gameObject);
            //Debug.DrawRay(offset, transform.forward * ((raycastLength / 2f)), Color.red, 10);
        }
        else if (Physics.Raycast(offset, transform.forward, out hit, Mathf.Min(30, raycastLength + (forwardSpeed)), layerMask))
        {
            currentAcceleratorLevel = .65f;
            //Debug.Log(hit.collider.gameObject);
            //Debug.DrawRay(offset, transform.forward * Mathf.Min(30, raycastLength + (forwardSpeed)), Color.yellow, 10);
        }
        else
        {
            currentAcceleratorLevel = 1;
        }

        //Calculate whether to break and cut off the motor if going too fast (too fast is either moving at > 30 speed, or moving faster than expected for the currentAcceleratorLevel).
        bool shouldSlowDown = forwardSpeed > 30 || (forwardSpeed > Mathf.Max(.5f,currentAcceleratorLevel) * 17.5f);
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
