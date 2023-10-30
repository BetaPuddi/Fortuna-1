using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    private float steerAngle;
    private float currentBreakForce;

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

    private InputActionAsset inputActionAsset;

    private InputAction moveAction;
    private InputAction brakeAction;

    private void Awake()
    {
        inputActionAsset = InputActionAsset.FromJson(@"{
            ""maps"": [
                {
                    ""name"": ""Player"",
                    ""actions"": [
                        {
                            ""name"": ""Move"",
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
                            ""name"": ""Brake"",
                            ""type"": ""Button"",
                            ""bindings"": [
                                {
                                    ""name"": ""ButtonPress"",
                                    ""type"": ""Value"",
                                    ""path"": ""<Gamepad>/buttonSouth""
                                }
                            ]
                        }
                    ],
                    ""bindings"": []
                }
            ]
        }");
    }

    private void OnEnable()
    {
        moveAction = inputActionAsset.FindAction("Move");
        brakeAction = inputActionAsset.FindAction("Brake");

        moveAction.Enable();
        brakeAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        brakeAction.Disable();
    }

    private void FixedUpdate()
    {
        HandleInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleInput()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float horizontalInput = moveInput.x;
        float verticalInput = moveInput.y;
        bool isBraking = brakeAction.ReadValue<float>() > 0;

        steerAngle = maxSteerAngle * horizontalInput;
        currentBreakForce = isBraking ? breakForce : 0;
    }

    private void HandleMotor()
    {
        float motorTorque = moveAction.ReadValue<Vector2>().y * motorForce;

        frontLeftWheelCollider.motorTorque = motorTorque;
        frontRightWheelCollider.motorTorque = motorTorque;

        ApplyBraking();
    }

    private void ApplyBraking()
    {
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
    }

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

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
