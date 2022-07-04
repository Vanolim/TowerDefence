// GENERATED AUTOMATICALLY FROM 'Assets/Plugins/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerStandalone"",
            ""id"": ""9987ad1f-19e7-4859-b360-62634fb3dd3a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b0957348-bf53-410f-8d60-d715a6402a04"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""fcf69254-e9ac-48ca-b53a-8af651413a17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cff398bf-2aad-4f24-a315-3e7f2b36378f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6f4e848c-a799-496b-871e-5f8e3b542cc3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3630be17-6e27-41a8-b2d6-4d6bd27c6d65"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6f90c4b9-3f93-4d2e-a466-6789cf54eb1f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""422f6423-e292-4cd0-b487-1608c66bd712"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4bf554b2-f193-437e-a5d0-0c5fd5cbf174"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""LeftMouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMobile"",
            ""id"": ""e18164ae-b573-4937-8605-ec9952d2cef9"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9d67df95-c2a4-4d56-a654-973b341fab3e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchClick"",
                    ""type"": ""Button"",
                    ""id"": ""b44d3c23-b3ec-4644-8c1f-7083c2b92e83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPostition"",
                    ""type"": ""Value"",
                    ""id"": ""853fa968-fa18-4b3a-b7f9-1cafd877961d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61efd8e5-4a7e-462c-b372-b7f0a548dd9c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7ca055d-9758-4003-a2c7-fe18f6ad76dc"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""TouchClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ea8e6e1-49ac-4d52-a81d-ae5288b1dacf"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""TouchPostition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
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
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerStandalone
        m_PlayerStandalone = asset.FindActionMap("PlayerStandalone", throwIfNotFound: true);
        m_PlayerStandalone_Move = m_PlayerStandalone.FindAction("Move", throwIfNotFound: true);
        m_PlayerStandalone_LeftMouseClick = m_PlayerStandalone.FindAction("LeftMouseClick", throwIfNotFound: true);
        // PlayerMobile
        m_PlayerMobile = asset.FindActionMap("PlayerMobile", throwIfNotFound: true);
        m_PlayerMobile_Move = m_PlayerMobile.FindAction("Move", throwIfNotFound: true);
        m_PlayerMobile_TouchClick = m_PlayerMobile.FindAction("TouchClick", throwIfNotFound: true);
        m_PlayerMobile_TouchPostition = m_PlayerMobile.FindAction("TouchPostition", throwIfNotFound: true);
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

    // PlayerStandalone
    private readonly InputActionMap m_PlayerStandalone;
    private IPlayerStandaloneActions m_PlayerStandaloneActionsCallbackInterface;
    private readonly InputAction m_PlayerStandalone_Move;
    private readonly InputAction m_PlayerStandalone_LeftMouseClick;
    public struct PlayerStandaloneActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerStandaloneActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerStandalone_Move;
        public InputAction @LeftMouseClick => m_Wrapper.m_PlayerStandalone_LeftMouseClick;
        public InputActionMap Get() { return m_Wrapper.m_PlayerStandalone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerStandaloneActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerStandaloneActions instance)
        {
            if (m_Wrapper.m_PlayerStandaloneActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerStandaloneActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerStandaloneActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerStandaloneActionsCallbackInterface.OnMove;
                @LeftMouseClick.started -= m_Wrapper.m_PlayerStandaloneActionsCallbackInterface.OnLeftMouseClick;
                @LeftMouseClick.performed -= m_Wrapper.m_PlayerStandaloneActionsCallbackInterface.OnLeftMouseClick;
                @LeftMouseClick.canceled -= m_Wrapper.m_PlayerStandaloneActionsCallbackInterface.OnLeftMouseClick;
            }
            m_Wrapper.m_PlayerStandaloneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LeftMouseClick.started += instance.OnLeftMouseClick;
                @LeftMouseClick.performed += instance.OnLeftMouseClick;
                @LeftMouseClick.canceled += instance.OnLeftMouseClick;
            }
        }
    }
    public PlayerStandaloneActions @PlayerStandalone => new PlayerStandaloneActions(this);

    // PlayerMobile
    private readonly InputActionMap m_PlayerMobile;
    private IPlayerMobileActions m_PlayerMobileActionsCallbackInterface;
    private readonly InputAction m_PlayerMobile_Move;
    private readonly InputAction m_PlayerMobile_TouchClick;
    private readonly InputAction m_PlayerMobile_TouchPostition;
    public struct PlayerMobileActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerMobileActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMobile_Move;
        public InputAction @TouchClick => m_Wrapper.m_PlayerMobile_TouchClick;
        public InputAction @TouchPostition => m_Wrapper.m_PlayerMobile_TouchPostition;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMobile; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMobileActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMobileActions instance)
        {
            if (m_Wrapper.m_PlayerMobileActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnMove;
                @TouchClick.started -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnTouchClick;
                @TouchClick.performed -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnTouchClick;
                @TouchClick.canceled -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnTouchClick;
                @TouchPostition.started -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnTouchPostition;
                @TouchPostition.performed -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnTouchPostition;
                @TouchPostition.canceled -= m_Wrapper.m_PlayerMobileActionsCallbackInterface.OnTouchPostition;
            }
            m_Wrapper.m_PlayerMobileActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @TouchClick.started += instance.OnTouchClick;
                @TouchClick.performed += instance.OnTouchClick;
                @TouchClick.canceled += instance.OnTouchClick;
                @TouchPostition.started += instance.OnTouchPostition;
                @TouchPostition.performed += instance.OnTouchPostition;
                @TouchPostition.canceled += instance.OnTouchPostition;
            }
        }
    }
    public PlayerMobileActions @PlayerMobile => new PlayerMobileActions(this);
    private int m_MouseandKeyboardSchemeIndex = -1;
    public InputControlScheme MouseandKeyboardScheme
    {
        get
        {
            if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
            return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IPlayerStandaloneActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLeftMouseClick(InputAction.CallbackContext context);
    }
    public interface IPlayerMobileActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnTouchClick(InputAction.CallbackContext context);
        void OnTouchPostition(InputAction.CallbackContext context);
    }
}
