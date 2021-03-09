// GENERATED AUTOMATICALLY FROM 'Assets/Input/Voyager.inputactions'

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
                    ""name"": ""SpeedUp"",
                    ""type"": ""Button"",
                    ""id"": ""5794ef30-cfc0-4ee8-8c8b-b9b3ea14f49a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlowDown"",
                    ""type"": ""Button"",
                    ""id"": ""90dd6bb0-e24f-4937-9d38-c7104b58e4d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""24f01dc8-cd25-467a-9ec5-cba93f0eb4b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnRight"",
                    ""type"": ""Button"",
                    ""id"": ""1f1bbd3b-2d3b-4dcf-b404-8f15194d167c"",
                    ""expectedControlType"": ""Button"",
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
                },
                {
                    ""name"": ""Camera_ZoomOut"",
                    ""type"": ""Button"",
                    ""id"": ""de8dad47-8227-4d6f-9a20-b374438eb98e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera_ZoomAxis"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5c7fa758-5f68-4052-9440-ab4ba76e01ad"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera_ZoomIn"",
                    ""type"": ""Button"",
                    ""id"": ""0d984c89-bd7f-4b86-b103-5865b5f8f39a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera_Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3e229eb7-86d5-4182-9ece-a4624723254c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera_RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""17e03a30-40d4-4553-822e-703e78431385"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera_RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""4f7c108e-5513-467a-966f-726314ed436c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveToSelection"",
                    ""type"": ""Button"",
                    ""id"": ""1761b0a3-3a92-4a23-9fda-cbc52973bfc6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""dc8048a8-3fc4-4fdf-a76b-7fab58257ac9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
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
                    ""id"": ""1e43904d-65f7-458f-9880-6d0591429ca9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpeedUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5e6723d-d662-4047-b24a-39ea59242e99"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""664434f8-8a85-4096-ac97-b41c8bcf3b67"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_ZoomOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf0f56e3-5efd-42a8-a4df-714819dc4e6b"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_ZoomAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21c59a08-df1c-48aa-9852-0186f4c9fdf9"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_ZoomIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""95c9609d-2fe6-49e0-af62-62f35695ad87"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0f80a6a1-69df-456a-8c45-e92486162acc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d8584549-5ae3-4696-b4b8-c36ed00266f8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""04fbe72c-bbcb-4edc-97d7-b78b8df9dc14"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""81897615-be3e-49cc-98a2-ac4928716908"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""742aec8c-d5a3-4f19-83e2-41325f84e6ae"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa94da13-0605-40c4-918d-3c15cd643d48"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07e27262-be7c-4223-bd09-23fc66c70fad"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ee1da67-aa8c-4016-96fc-c4510b488090"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera_RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1dbeda3-bc6f-481a-a657-91ab782116e1"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveToSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d921cdeb-d301-4e56-9761-f87a50076ff7"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
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
                },
                {
                    ""name"": ""Place"",
                    ""type"": ""Button"",
                    ""id"": ""e06a28ed-eeea-4343-ac03-61bb07abf26c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveUpLevel"",
                    ""type"": ""Button"",
                    ""id"": ""ecab820d-d6b7-4a60-b647-d965224b9b36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDownLevel"",
                    ""type"": ""Button"",
                    ""id"": ""8cab29bc-4744-4aba-aeb2-0d2dc4af9f77"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""d57600cd-7325-4e7f-a3c8-7b3f3d0c1c56"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c50131e3-3e99-4fe3-9df9-8f54924496e8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUpLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d884e17a-257c-429d-a75c-df45f6ade0cf"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDownLevel"",
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
        m_Flight_SpeedUp = m_Flight.FindAction("SpeedUp", throwIfNotFound: true);
        m_Flight_SlowDown = m_Flight.FindAction("SlowDown", throwIfNotFound: true);
        m_Flight_TurnLeft = m_Flight.FindAction("TurnLeft", throwIfNotFound: true);
        m_Flight_TurnRight = m_Flight.FindAction("TurnRight", throwIfNotFound: true);
        m_Flight_Laser = m_Flight.FindAction("Laser", throwIfNotFound: true);
        m_Flight_Camera_ZoomOut = m_Flight.FindAction("Camera_ZoomOut", throwIfNotFound: true);
        m_Flight_Camera_ZoomAxis = m_Flight.FindAction("Camera_ZoomAxis", throwIfNotFound: true);
        m_Flight_Camera_ZoomIn = m_Flight.FindAction("Camera_ZoomIn", throwIfNotFound: true);
        m_Flight_Camera_Move = m_Flight.FindAction("Camera_Move", throwIfNotFound: true);
        m_Flight_Camera_RotateLeft = m_Flight.FindAction("Camera_RotateLeft", throwIfNotFound: true);
        m_Flight_Camera_RotateRight = m_Flight.FindAction("Camera_RotateRight", throwIfNotFound: true);
        m_Flight_MoveToSelection = m_Flight.FindAction("MoveToSelection", throwIfNotFound: true);
        m_Flight_Selection = m_Flight.FindAction("Selection", throwIfNotFound: true);
        // Build
        m_Build = asset.FindActionMap("Build", throwIfNotFound: true);
        m_Build_Flight = m_Build.FindAction("Flight", throwIfNotFound: true);
        m_Build_Place = m_Build.FindAction("Place", throwIfNotFound: true);
        m_Build_MoveUpLevel = m_Build.FindAction("MoveUpLevel", throwIfNotFound: true);
        m_Build_MoveDownLevel = m_Build.FindAction("MoveDownLevel", throwIfNotFound: true);
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
    private readonly InputAction m_Flight_SpeedUp;
    private readonly InputAction m_Flight_SlowDown;
    private readonly InputAction m_Flight_TurnLeft;
    private readonly InputAction m_Flight_TurnRight;
    private readonly InputAction m_Flight_Laser;
    private readonly InputAction m_Flight_Camera_ZoomOut;
    private readonly InputAction m_Flight_Camera_ZoomAxis;
    private readonly InputAction m_Flight_Camera_ZoomIn;
    private readonly InputAction m_Flight_Camera_Move;
    private readonly InputAction m_Flight_Camera_RotateLeft;
    private readonly InputAction m_Flight_Camera_RotateRight;
    private readonly InputAction m_Flight_MoveToSelection;
    private readonly InputAction m_Flight_Selection;
    public struct FlightActions
    {
        private @Voyager m_Wrapper;
        public FlightActions(@Voyager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Build => m_Wrapper.m_Flight_Build;
        public InputAction @SpeedUp => m_Wrapper.m_Flight_SpeedUp;
        public InputAction @SlowDown => m_Wrapper.m_Flight_SlowDown;
        public InputAction @TurnLeft => m_Wrapper.m_Flight_TurnLeft;
        public InputAction @TurnRight => m_Wrapper.m_Flight_TurnRight;
        public InputAction @Laser => m_Wrapper.m_Flight_Laser;
        public InputAction @Camera_ZoomOut => m_Wrapper.m_Flight_Camera_ZoomOut;
        public InputAction @Camera_ZoomAxis => m_Wrapper.m_Flight_Camera_ZoomAxis;
        public InputAction @Camera_ZoomIn => m_Wrapper.m_Flight_Camera_ZoomIn;
        public InputAction @Camera_Move => m_Wrapper.m_Flight_Camera_Move;
        public InputAction @Camera_RotateLeft => m_Wrapper.m_Flight_Camera_RotateLeft;
        public InputAction @Camera_RotateRight => m_Wrapper.m_Flight_Camera_RotateRight;
        public InputAction @MoveToSelection => m_Wrapper.m_Flight_MoveToSelection;
        public InputAction @Selection => m_Wrapper.m_Flight_Selection;
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
                @SpeedUp.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnSpeedUp;
                @SlowDown.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnSlowDown;
                @SlowDown.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnSlowDown;
                @SlowDown.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnSlowDown;
                @TurnLeft.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnTurnLeft;
                @TurnLeft.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnTurnLeft;
                @TurnRight.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnTurnRight;
                @TurnRight.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnTurnRight;
                @TurnRight.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnTurnRight;
                @Laser.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnLaser;
                @Laser.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnLaser;
                @Laser.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnLaser;
                @Camera_ZoomOut.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomOut;
                @Camera_ZoomOut.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomOut;
                @Camera_ZoomOut.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomOut;
                @Camera_ZoomAxis.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomAxis;
                @Camera_ZoomAxis.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomAxis;
                @Camera_ZoomAxis.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomAxis;
                @Camera_ZoomIn.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomIn;
                @Camera_ZoomIn.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomIn;
                @Camera_ZoomIn.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_ZoomIn;
                @Camera_Move.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_Move;
                @Camera_Move.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_Move;
                @Camera_Move.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_Move;
                @Camera_RotateLeft.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_RotateLeft;
                @Camera_RotateLeft.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_RotateLeft;
                @Camera_RotateLeft.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_RotateLeft;
                @Camera_RotateRight.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_RotateRight;
                @Camera_RotateRight.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_RotateRight;
                @Camera_RotateRight.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera_RotateRight;
                @MoveToSelection.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnMoveToSelection;
                @MoveToSelection.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnMoveToSelection;
                @MoveToSelection.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnMoveToSelection;
                @Selection.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnSelection;
                @Selection.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnSelection;
                @Selection.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnSelection;
            }
            m_Wrapper.m_FlightActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @SpeedUp.started += instance.OnSpeedUp;
                @SpeedUp.performed += instance.OnSpeedUp;
                @SpeedUp.canceled += instance.OnSpeedUp;
                @SlowDown.started += instance.OnSlowDown;
                @SlowDown.performed += instance.OnSlowDown;
                @SlowDown.canceled += instance.OnSlowDown;
                @TurnLeft.started += instance.OnTurnLeft;
                @TurnLeft.performed += instance.OnTurnLeft;
                @TurnLeft.canceled += instance.OnTurnLeft;
                @TurnRight.started += instance.OnTurnRight;
                @TurnRight.performed += instance.OnTurnRight;
                @TurnRight.canceled += instance.OnTurnRight;
                @Laser.started += instance.OnLaser;
                @Laser.performed += instance.OnLaser;
                @Laser.canceled += instance.OnLaser;
                @Camera_ZoomOut.started += instance.OnCamera_ZoomOut;
                @Camera_ZoomOut.performed += instance.OnCamera_ZoomOut;
                @Camera_ZoomOut.canceled += instance.OnCamera_ZoomOut;
                @Camera_ZoomAxis.started += instance.OnCamera_ZoomAxis;
                @Camera_ZoomAxis.performed += instance.OnCamera_ZoomAxis;
                @Camera_ZoomAxis.canceled += instance.OnCamera_ZoomAxis;
                @Camera_ZoomIn.started += instance.OnCamera_ZoomIn;
                @Camera_ZoomIn.performed += instance.OnCamera_ZoomIn;
                @Camera_ZoomIn.canceled += instance.OnCamera_ZoomIn;
                @Camera_Move.started += instance.OnCamera_Move;
                @Camera_Move.performed += instance.OnCamera_Move;
                @Camera_Move.canceled += instance.OnCamera_Move;
                @Camera_RotateLeft.started += instance.OnCamera_RotateLeft;
                @Camera_RotateLeft.performed += instance.OnCamera_RotateLeft;
                @Camera_RotateLeft.canceled += instance.OnCamera_RotateLeft;
                @Camera_RotateRight.started += instance.OnCamera_RotateRight;
                @Camera_RotateRight.performed += instance.OnCamera_RotateRight;
                @Camera_RotateRight.canceled += instance.OnCamera_RotateRight;
                @MoveToSelection.started += instance.OnMoveToSelection;
                @MoveToSelection.performed += instance.OnMoveToSelection;
                @MoveToSelection.canceled += instance.OnMoveToSelection;
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
            }
        }
    }
    public FlightActions @Flight => new FlightActions(this);

    // Build
    private readonly InputActionMap m_Build;
    private IBuildActions m_BuildActionsCallbackInterface;
    private readonly InputAction m_Build_Flight;
    private readonly InputAction m_Build_Place;
    private readonly InputAction m_Build_MoveUpLevel;
    private readonly InputAction m_Build_MoveDownLevel;
    public struct BuildActions
    {
        private @Voyager m_Wrapper;
        public BuildActions(@Voyager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Flight => m_Wrapper.m_Build_Flight;
        public InputAction @Place => m_Wrapper.m_Build_Place;
        public InputAction @MoveUpLevel => m_Wrapper.m_Build_MoveUpLevel;
        public InputAction @MoveDownLevel => m_Wrapper.m_Build_MoveDownLevel;
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
                @Place.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnPlace;
                @Place.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnPlace;
                @Place.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnPlace;
                @MoveUpLevel.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnMoveUpLevel;
                @MoveUpLevel.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnMoveUpLevel;
                @MoveUpLevel.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnMoveUpLevel;
                @MoveDownLevel.started -= m_Wrapper.m_BuildActionsCallbackInterface.OnMoveDownLevel;
                @MoveDownLevel.performed -= m_Wrapper.m_BuildActionsCallbackInterface.OnMoveDownLevel;
                @MoveDownLevel.canceled -= m_Wrapper.m_BuildActionsCallbackInterface.OnMoveDownLevel;
            }
            m_Wrapper.m_BuildActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Flight.started += instance.OnFlight;
                @Flight.performed += instance.OnFlight;
                @Flight.canceled += instance.OnFlight;
                @Place.started += instance.OnPlace;
                @Place.performed += instance.OnPlace;
                @Place.canceled += instance.OnPlace;
                @MoveUpLevel.started += instance.OnMoveUpLevel;
                @MoveUpLevel.performed += instance.OnMoveUpLevel;
                @MoveUpLevel.canceled += instance.OnMoveUpLevel;
                @MoveDownLevel.started += instance.OnMoveDownLevel;
                @MoveDownLevel.performed += instance.OnMoveDownLevel;
                @MoveDownLevel.canceled += instance.OnMoveDownLevel;
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
        void OnSpeedUp(InputAction.CallbackContext context);
        void OnSlowDown(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnLaser(InputAction.CallbackContext context);
        void OnCamera_ZoomOut(InputAction.CallbackContext context);
        void OnCamera_ZoomAxis(InputAction.CallbackContext context);
        void OnCamera_ZoomIn(InputAction.CallbackContext context);
        void OnCamera_Move(InputAction.CallbackContext context);
        void OnCamera_RotateLeft(InputAction.CallbackContext context);
        void OnCamera_RotateRight(InputAction.CallbackContext context);
        void OnMoveToSelection(InputAction.CallbackContext context);
        void OnSelection(InputAction.CallbackContext context);
    }
    public interface IBuildActions
    {
        void OnFlight(InputAction.CallbackContext context);
        void OnPlace(InputAction.CallbackContext context);
        void OnMoveUpLevel(InputAction.CallbackContext context);
        void OnMoveDownLevel(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
