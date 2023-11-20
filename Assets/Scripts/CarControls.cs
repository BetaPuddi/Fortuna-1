using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    //steering angle and how strong the car is braking currently
    private float steerAngle;
    private float currentBreakForce;
    //how fast the car is, how strong the car is braking, max steer angle to prevent overturn
    [SerializeField] public float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    //colliders referencing car
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    //transforms referencing car
    [SerializeField] private Transform rearRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    //all input action stuff
    private InputActionAsset inputActionAsset;

    private InputAction moveAction;
    private InputAction brakeAction;
    private InputAction gasAction; 

    float sensitivity;
    //json bcs of issues with input system
    private void Awake()
    {
        inputActionAsset = InputActionAsset.FromJson(@"{
            ""maps"": [
                {
                    ""name"": ""Player"",
                    ""actions"": [
                        {
                            ""name"": ""ControllerHorizontal"",
                            ""type"": ""Value"",
                            ""bindings"": [
                                {
                                    ""name"": ""Stick"",
                                    ""type"": ""Value"",
                                    ""path"": ""<Gamepad>/leftStick""
                                }
                            ]
                        },
                        {
                            ""name"": ""ControllerBrake"",
                            ""type"": ""Button"",
                            ""bindings"": [
                                {
                                    ""name"": ""ButtonPress"",
                                    ""type"": ""Value"",
                                    ""path"": ""<Gamepad>/buttonSouth""
                                }
                            ]
                        },
                        {
                            ""name"": ""Gas"",
                            ""type"": ""Button"",
                            ""bindings"": [
                                {
                                    ""name"": ""ButtonPress"",
                                    ""type"": ""Value"",
                                    ""path"": ""<Gamepad>/leftTrigger""
                                }
                            ]
                        }
                    ],
                    ""bindings"": []
                }
            ]
        }");
    }
    //when button pressed......
    private void OnEnable()
    {
        moveAction = inputActionAsset.FindAction("ControllerHorizontal");
        brakeAction = inputActionAsset.FindAction("ControllerBrake");
        gasAction = inputActionAsset.FindAction("Gas");

        moveAction.Enable();
        brakeAction.Enable();
        gasAction.Enable();
        PersistentData.persistentData.loadPlayerPrefs();
        sensitivity = PersistentData.persistentData.getSensitivity();
    }
    //when button disabled...
    private void OnDisable()
    {
        moveAction.Disable();
        brakeAction.Disable();
        gasAction.Disable();
    }
    //calling all mechanics
    private void FixedUpdate()
    {
        HandleInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    //handling the player input
    private void HandleInput()
    {
        float horizontalInput = sensitivity * moveAction.ReadValue<Vector2>().x;
        bool isBraking = sensitivity * brakeAction.ReadValue<float>() > 0;
        bool isGas = sensitivity * gasAction.ReadValue<float>() > 0;

        
        steerAngle = maxSteerAngle * horizontalInput;
        currentBreakForce = isBraking ? breakForce : 0;

        float gasInput = isGas ? 1.0f : 0.0f;

        float verticalInput = 0.0f;

        if (isGas || moveAction.ReadValue<Vector2>().y < 0)
        {
            verticalInput = Mathf.Abs(moveAction.ReadValue<Vector2>().y);
            gasInput = 0.0f;
        }

        float motorInput = Mathf.Max(gasInput, -verticalInput);
    }
    //car forward movement
    private void HandleMotor()
    {
        float gasInput = gasAction.ReadValue<float>();
        float verticalInput = moveAction.ReadValue<Vector2>().y;

        if (gasInput > 0)
        {
            verticalInput = 1.0f;
        }
        else if (verticalInput < 0 && gasInput == 0)
        {
            verticalInput = -Mathf.Abs(verticalInput);
        }
        else
        {
            verticalInput = 0.0f;
        }

        float motorTorque = verticalInput * motorForce;

        frontLeftWheelCollider.motorTorque = motorTorque;
        frontRightWheelCollider.motorTorque = motorTorque;

        ApplyBraking();
    }
    //braking
    private void ApplyBraking()
    {
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
    }
    //left right steering
    private void HandleSteering()
    {
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }
    //collision etc
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }
    //getting rotations and positions
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
