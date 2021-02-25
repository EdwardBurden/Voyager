// GENERATED AUTOMATICALLY FROM 'Assets/Voyager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Voyager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Voyager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Voyager"",
    ""maps"": [
        {
            ""name"": ""Flight"",
            ""id"": ""f725c211-0831-4f99-845b-dd7c11f92f90"",
            ""actions"": [
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""a1804c2f-9116-4946-9fc5-e4c97ca62634"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""5794ef30-cfc0-4ee8-8c8b-b9b3ea14f49a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reverse"",
                    ""type"": ""Button"",
                    ""id"": ""90dd6bb0-e24f-4937-9d38-c7104b58e4d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""1388fa7b-6548-419b-8c4f-77643ed01218"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Laser"",
                    ""type"": ""Button"",
                    ""id"": ""731e646a-33c3-4c5b-846c-829001bf3265"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0b769275-960c-423e-ad6e-1d1240da7572"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75a30c2b-f2eb-43ff-8341-185cff7788af"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5846055-9e27-41c1-8f9c-5f292944d749"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b936c30d-9883-45e6-a18f-b91278d53610"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""657c0792-9919-4f15-9f9a-a74842a92b30"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ec90cd1-c551-4834-a996-b468ddd8c0bd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""81bda21e-bdd0-4441-b2a2-07944f1a793e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3a61e2db-b37a-4eb3-a2bc-eaa35ecfa687"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0de6f5ac-9af9-4e6f-8963-34d6d227ab42"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f7b3ccb1-9b64-4e16-8fda-25a2da87a860"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6879ae47-8121-4e96-a530-de6cae7ca235"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fbe570f4-3ebc-45fb-bbc9-e171b2b2198a"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Laser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aea2396b-d30f-4683-8d96-e668e08a7c28"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Laser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Build"",
            ""id"": ""fbda01a2-aa40-4519-92fe-892b43746b0a"",
            ""actions"": [
                {
                    ""name"": ""Flight"",
                    ""type"": ""Button"",
                    ""id"": ""358e42e8-71ca-4c98-b2eb-74605e4f37f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5157fb8f-6f7c-40ef-9523-2ed67a290456"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""da9d3cef-1f6b-4ccf-879b-8463e9c7a217"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""50f7d3fd-545a-4d6a-b375-b7c5af9f80cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0462c022-ec6a-406b-835a-71fe2f27887c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Flight
        m_Flight = asset.FindActionMap("Flight", throwIfNotFound: true);
        m_Flight_Build = m_Flight.FindAction("Build", throwIfNotFound: true);
        m_Flight_Accelerate = m_Flight.FindAction("Accelerate", throwIfNotFound: true);
        m_Flight_Reverse = m_Flight.FindAction("Reverse", throwIfNotFound: true);
        m_Flight_Rotate = m_Flight.FindAction("Rotate", throwIfNotFound: true);
        m_Flight_Laser = m_Flight.FindAction("Laser", throwIfNotFound: true);
        // Build
        m_Build = asset.FindActionMap("Build", throwIfNotFound: true);
        m_Build_Flight = m_Build.FindAction("Flight", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
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

    // Flight
    private readonly InputActionMap m_Flight;
    private IFlightActions m_FlightActionsCallbackInterface;
    private readonly InputAction m_Flight_Build;
    private readonly InputAction m_Flight_Accelerate;
    private readonly InputAction m_Flight_Reverse;
    private readonly InputAction m_Flight_Rotate;
    private readonly InputAction m_Flight_Laser;
    public struct FlightActions
    {
        private @Voyager m_Wrapper;
        public FlightActions(@Voyager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Build => m_Wrapper.m_Flight_Build;
        public InputAction @Accelerate => m_Wrapper.m_Flight_Accelerate;
        public InputAction @Reverse => m_Wrapper.m_Flight_Reverse;
        public InputAction @Rotate => m_Wrapper.m_Flight_Rotate;
        public InputAction @Laser => m_Wrapper.m_Flight_Laser;
        public InputActionMap Get() { return m_Wrapper.m_Flight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FlightActions set) { return set.Get(); }
        public void SetCallbacks(IFlightActions instance)
        {
            if (m_Wrapper.m_FlightActionsCallbackInterface != null)
            {
                @Build.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnBuild;
                @Build.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnBuild;
                @Build.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnBuild;
                @Accelerate.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnAccelerate;
                @Reverse.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnReverse;
                @Reverse.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnReverse;
                @Reverse.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnReverse;
                @Rotate.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnRotate;
                @Laser.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnLaser;
                @Laser.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnLaser;
                @Laser.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnLaser;
            }
            m_Wrapper.m_FlightActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Reverse.started += instance.OnReverse;
                @Reverse.performed += instance.OnReverse;
                @Reverse.canceled += instance.OnReverse;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Laser.started += instance.OnLaser;
                @Laser.performed += instance.OnLaser;
                @Laser.canceled += instance.OnLaser;
            }
        }
    }
    public FlightActions @Flight => new FlightActions(this);

    // Build
    private readonly InputActionMap m_Build;
    private IBuildActions m_BuildActionsCallbackInterface;
    private readonly InputAction m_Build_Flight;
    public struct BuildActions
    {
        private @Voyager m_Wrapper;
        public BuildActions(@Voyager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Flight => m_Wrapper.m_Build_Flight;
        public InputActionMap Get() { return m_Wrapper.m_Build; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BuildActions set) { return set.Get(); }
        public void SetCallbacks(IBuildActions instance)
        {
            if (m_Wrapper.m_BuildActionsCallbackInterface != null)
            {
                @Flight.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnFlight;
                @Flight.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnFlight;
                @Flight.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnFlight;
            }
            m_Wrapper.m_BuildActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Flight.started += instance.OnFlight;
                @Flight.performed += instance.OnFlight;
                @Flight.canceled += instance.OnFlight;
            }
        }
    }
    public BuildActions @Build => new BuildActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Newaction;
    public struct MenuActions
    {
        private @Voyager m_Wrapper;
        public MenuActions(@Voyager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Menu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IFlightActions
    {
        void OnBuild(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnReverse(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnLaser(InputAction.CallbackContext context);
    }
    public interface IBuildActions
    {
        void OnFlight(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
