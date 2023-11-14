//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""ControllerBrake"",
            ""id"": ""f803072e-06f0-4f7a-8de5-845deee97800"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""e218a63c-9ef0-4ca5-bd82-a26b9992ca29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3ea32013-c374-4058-9ad3-0f7d1fe804dd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ControllerPowerup"",
            ""id"": ""579fa11b-734f-4651-b9ed-876e875a52fc"",
            ""actions"": [
                {
                    ""name"": ""UsePowerup"",
                    ""type"": ""Button"",
                    ""id"": ""17170a2b-d3b0-4e79-b354-3db6f735c00e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""430ceb6c-0afb-4a8a-a420-ff103ad7f0c4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UsePowerup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gas"",
            ""id"": ""fb3c8cea-8648-42d9-a297-d9a489394a1b"",
            ""actions"": [
                {
                    ""name"": ""Gas"",
                    ""type"": ""Button"",
                    ""id"": ""9a7bfd4a-6598-440a-bcb6-f6e30d8c75fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b8b12a1a-7013-4211-8450-c927448713e8"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ControllerHorizontal"",
            ""id"": ""f7b94831-69c2-4746-9ad8-3be364b658fd"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""PassThrough"",
                    ""id"": ""51bed6bf-bb9b-4de7-93df-705557b3b1e6"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9624418a-7598-4a3b-8cb6-ad6d4d41d289"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""326afadf-7c4e-4fd5-9701-e1d905bb9f42"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""188580de-6453-4920-a852-dfd983301eff"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""62120722-7790-42ed-81bf-99d905bf1fd2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c73a1dbb-7e69-4fd5-9979-6c995d3e722f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ControllerBrake
        m_ControllerBrake = asset.FindActionMap("ControllerBrake", throwIfNotFound: true);
        m_ControllerBrake_Newaction = m_ControllerBrake.FindAction("New action", throwIfNotFound: true);
        // ControllerPowerup
        m_ControllerPowerup = asset.FindActionMap("ControllerPowerup", throwIfNotFound: true);
        m_ControllerPowerup_UsePowerup = m_ControllerPowerup.FindAction("UsePowerup", throwIfNotFound: true);
        // Gas
        m_Gas = asset.FindActionMap("Gas", throwIfNotFound: true);
        m_Gas_Gas = m_Gas.FindAction("Gas", throwIfNotFound: true);
        // ControllerHorizontal
        m_ControllerHorizontal = asset.FindActionMap("ControllerHorizontal", throwIfNotFound: true);
        m_ControllerHorizontal_Newaction = m_ControllerHorizontal.FindAction("New action", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ControllerBrake
    private readonly InputActionMap m_ControllerBrake;
    private List<IControllerBrakeActions> m_ControllerBrakeActionsCallbackInterfaces = new List<IControllerBrakeActions>();
    private readonly InputAction m_ControllerBrake_Newaction;
    public struct ControllerBrakeActions
    {
        private @InputActions m_Wrapper;
        public ControllerBrakeActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_ControllerBrake_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_ControllerBrake; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerBrakeActions set) { return set.Get(); }
        public void AddCallbacks(IControllerBrakeActions instance)
        {
            if (instance == null || m_Wrapper.m_ControllerBrakeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControllerBrakeActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IControllerBrakeActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IControllerBrakeActions instance)
        {
            if (m_Wrapper.m_ControllerBrakeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControllerBrakeActions instance)
        {
            foreach (var item in m_Wrapper.m_ControllerBrakeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControllerBrakeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControllerBrakeActions @ControllerBrake => new ControllerBrakeActions(this);

    // ControllerPowerup
    private readonly InputActionMap m_ControllerPowerup;
    private List<IControllerPowerupActions> m_ControllerPowerupActionsCallbackInterfaces = new List<IControllerPowerupActions>();
    private readonly InputAction m_ControllerPowerup_UsePowerup;
    public struct ControllerPowerupActions
    {
        private @InputActions m_Wrapper;
        public ControllerPowerupActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UsePowerup => m_Wrapper.m_ControllerPowerup_UsePowerup;
        public InputActionMap Get() { return m_Wrapper.m_ControllerPowerup; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerPowerupActions set) { return set.Get(); }
        public void AddCallbacks(IControllerPowerupActions instance)
        {
            if (instance == null || m_Wrapper.m_ControllerPowerupActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControllerPowerupActionsCallbackInterfaces.Add(instance);
            @UsePowerup.started += instance.OnUsePowerup;
            @UsePowerup.performed += instance.OnUsePowerup;
            @UsePowerup.canceled += instance.OnUsePowerup;
        }

        private void UnregisterCallbacks(IControllerPowerupActions instance)
        {
            @UsePowerup.started -= instance.OnUsePowerup;
            @UsePowerup.performed -= instance.OnUsePowerup;
            @UsePowerup.canceled -= instance.OnUsePowerup;
        }

        public void RemoveCallbacks(IControllerPowerupActions instance)
        {
            if (m_Wrapper.m_ControllerPowerupActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControllerPowerupActions instance)
        {
            foreach (var item in m_Wrapper.m_ControllerPowerupActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControllerPowerupActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControllerPowerupActions @ControllerPowerup => new ControllerPowerupActions(this);

    // Gas
    private readonly InputActionMap m_Gas;
    private List<IGasActions> m_GasActionsCallbackInterfaces = new List<IGasActions>();
    private readonly InputAction m_Gas_Gas;
    public struct GasActions
    {
        private @InputActions m_Wrapper;
        public GasActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Gas => m_Wrapper.m_Gas_Gas;
        public InputActionMap Get() { return m_Wrapper.m_Gas; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GasActions set) { return set.Get(); }
        public void AddCallbacks(IGasActions instance)
        {
            if (instance == null || m_Wrapper.m_GasActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GasActionsCallbackInterfaces.Add(instance);
            @Gas.started += instance.OnGas;
            @Gas.performed += instance.OnGas;
            @Gas.canceled += instance.OnGas;
        }

        private void UnregisterCallbacks(IGasActions instance)
        {
            @Gas.started -= instance.OnGas;
            @Gas.performed -= instance.OnGas;
            @Gas.canceled -= instance.OnGas;
        }

        public void RemoveCallbacks(IGasActions instance)
        {
            if (m_Wrapper.m_GasActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGasActions instance)
        {
            foreach (var item in m_Wrapper.m_GasActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GasActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GasActions @Gas => new GasActions(this);

    // ControllerHorizontal
    private readonly InputActionMap m_ControllerHorizontal;
    private List<IControllerHorizontalActions> m_ControllerHorizontalActionsCallbackInterfaces = new List<IControllerHorizontalActions>();
    private readonly InputAction m_ControllerHorizontal_Newaction;
    public struct ControllerHorizontalActions
    {
        private @InputActions m_Wrapper;
        public ControllerHorizontalActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_ControllerHorizontal_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_ControllerHorizontal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerHorizontalActions set) { return set.Get(); }
        public void AddCallbacks(IControllerHorizontalActions instance)
        {
            if (instance == null || m_Wrapper.m_ControllerHorizontalActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControllerHorizontalActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IControllerHorizontalActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IControllerHorizontalActions instance)
        {
            if (m_Wrapper.m_ControllerHorizontalActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControllerHorizontalActions instance)
        {
            foreach (var item in m_Wrapper.m_ControllerHorizontalActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControllerHorizontalActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControllerHorizontalActions @ControllerHorizontal => new ControllerHorizontalActions(this);
    public interface IControllerBrakeActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IControllerPowerupActions
    {
        void OnUsePowerup(InputAction.CallbackContext context);
    }
    public interface IGasActions
    {
        void OnGas(InputAction.CallbackContext context);
    }
    public interface IControllerHorizontalActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
