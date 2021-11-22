// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerInputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputController"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""f700c0a6-af2b-4165-9a4c-1f3798988065"",
            ""actions"": [
                {
                    ""name"": ""Delta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3778f035-b838-40cd-86d9-8ff612415227"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""0848a6ea-e833-489e-9157-5f708f07c4fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e95bb839-fdad-4774-ac43-e60331701e05"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b6be227-6069-442f-86fb-fb7872dfb108"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Delta = m_Movement.FindAction("Delta", throwIfNotFound: true);
        m_Movement_Click = m_Movement.FindAction("Click", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Delta;
    private readonly InputAction m_Movement_Click;
    public struct MovementActions
    {
        private @PlayerInputController m_Wrapper;
        public MovementActions(@PlayerInputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Delta => m_Wrapper.m_Movement_Delta;
        public InputAction @Click => m_Wrapper.m_Movement_Click;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Delta.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDelta;
                @Click.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnDelta(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}
