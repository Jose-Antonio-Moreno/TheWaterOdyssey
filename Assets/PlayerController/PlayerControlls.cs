// GENERATED AUTOMATICALLY FROM 'Assets/PlayerController/PlayerControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""ebd34ef9-d557-4cac-9f42-08c121a2b5dd"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""92a1b040-4ee6-40a7-be5d-293ffea43d78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3cf4450b-db73-4595-8040-d1f1ff3c2ac7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomIn"",
                    ""type"": ""Button"",
                    ""id"": ""95c1b164-b240-4147-87e5-0cb8b5f138d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZoomOut"",
                    ""type"": ""Button"",
                    ""id"": ""bca6e379-ee9c-40ac-9ec2-fdd74b429d6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""Value"",
                    ""id"": ""7825df78-d6e6-42bc-aef4-09c4c57644c7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Decrease"",
                    ""type"": ""Button"",
                    ""id"": ""174b2f75-2708-4e8e-902e-73fadb1c0154"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""47cf9766-e77f-4f37-bd07-fa8121046288"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""4cd0812f-501f-4eff-a856-e0cfcbb3af63"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""e5ca1dff-1d53-45c7-93b6-c7ed8fb1177c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SetSkillSelectorPanel"",
                    ""type"": ""Button"",
                    ""id"": ""e8135016-5c88-4c0a-8468-67b3fec376d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ultimate"",
                    ""type"": ""Button"",
                    ""id"": ""d7269b02-dfc7-47c1-bad8-40e8b836e8b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6487a70-b7fd-467f-bb67-4494a4c84463"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae3d6d26-0ca5-4a9e-8e36-e82b46d272d5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cc4f4e4-0427-4d82-9b0e-ee9bee07cc00"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0434e8a8-af64-448d-85b7-883c34f10c33"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf4d194f-c90d-49e5-8ecd-8d5db583ad69"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87c22b0a-32ee-4f4b-aa16-87a67a70f6cd"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decrease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9d9fe01-521a-4082-994b-cbef99c05b93"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""168dbf73-8557-45f8-ad8a-76ad8a984514"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c02a8a0-0361-41cc-8ca6-46d25dffca14"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f539e51-d395-4c15-8507-95d4aa2f1bf8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aefe9dbb-7408-4f9b-906e-adc20b56bba9"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetSkillSelectorPanel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4986ffd1-0509-4db4-acbd-69e5bea609e2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ultimate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_ZoomIn = m_Gameplay.FindAction("ZoomIn", throwIfNotFound: true);
        m_Gameplay_ZoomOut = m_Gameplay.FindAction("ZoomOut", throwIfNotFound: true);
        m_Gameplay_MouseLook = m_Gameplay.FindAction("MouseLook", throwIfNotFound: true);
        m_Gameplay_Decrease = m_Gameplay.FindAction("Decrease", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_Aim = m_Gameplay.FindAction("Aim", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_SetSkillSelectorPanel = m_Gameplay.FindAction("SetSkillSelectorPanel", throwIfNotFound: true);
        m_Gameplay_Ultimate = m_Gameplay.FindAction("Ultimate", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_ZoomIn;
    private readonly InputAction m_Gameplay_ZoomOut;
    private readonly InputAction m_Gameplay_MouseLook;
    private readonly InputAction m_Gameplay_Decrease;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_Aim;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_SetSkillSelectorPanel;
    private readonly InputAction m_Gameplay_Ultimate;
    public struct GameplayActions
    {
        private @PlayerControlls m_Wrapper;
        public GameplayActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @ZoomIn => m_Wrapper.m_Gameplay_ZoomIn;
        public InputAction @ZoomOut => m_Wrapper.m_Gameplay_ZoomOut;
        public InputAction @MouseLook => m_Wrapper.m_Gameplay_MouseLook;
        public InputAction @Decrease => m_Wrapper.m_Gameplay_Decrease;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @Aim => m_Wrapper.m_Gameplay_Aim;
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @SetSkillSelectorPanel => m_Wrapper.m_Gameplay_SetSkillSelectorPanel;
        public InputAction @Ultimate => m_Wrapper.m_Gameplay_Ultimate;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @ZoomIn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomIn;
                @ZoomIn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomIn;
                @ZoomIn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomIn;
                @ZoomOut.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomOut;
                @ZoomOut.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomOut;
                @ZoomOut.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnZoomOut;
                @MouseLook.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseLook;
                @Decrease.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDecrease;
                @Decrease.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDecrease;
                @Decrease.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDecrease;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Aim.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @SetSkillSelectorPanel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSetSkillSelectorPanel;
                @SetSkillSelectorPanel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSetSkillSelectorPanel;
                @SetSkillSelectorPanel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSetSkillSelectorPanel;
                @Ultimate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Ultimate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Ultimate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ZoomIn.started += instance.OnZoomIn;
                @ZoomIn.performed += instance.OnZoomIn;
                @ZoomIn.canceled += instance.OnZoomIn;
                @ZoomOut.started += instance.OnZoomOut;
                @ZoomOut.performed += instance.OnZoomOut;
                @ZoomOut.canceled += instance.OnZoomOut;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @Decrease.started += instance.OnDecrease;
                @Decrease.performed += instance.OnDecrease;
                @Decrease.canceled += instance.OnDecrease;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @SetSkillSelectorPanel.started += instance.OnSetSkillSelectorPanel;
                @SetSkillSelectorPanel.performed += instance.OnSetSkillSelectorPanel;
                @SetSkillSelectorPanel.canceled += instance.OnSetSkillSelectorPanel;
                @Ultimate.started += instance.OnUltimate;
                @Ultimate.performed += instance.OnUltimate;
                @Ultimate.canceled += instance.OnUltimate;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnZoomIn(InputAction.CallbackContext context);
        void OnZoomOut(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
        void OnDecrease(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnSetSkillSelectorPanel(InputAction.CallbackContext context);
        void OnUltimate(InputAction.CallbackContext context);
    }
}
