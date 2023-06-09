//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/InputSystem/PlayerActions.inputactions
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

public partial class @PlayerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Movimento"",
            ""id"": ""a9022b18-659b-4ba2-9fa7-e08514661e45"",
            ""actions"": [
                {
                    ""name"": ""Norte/Sul"",
                    ""type"": ""Button"",
                    ""id"": ""93e5d99a-5763-40f7-9df0-78ca912f1af4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Leste/Oeste"",
                    ""type"": ""Button"",
                    ""id"": ""e7f4a3ec-b3db-4d5b-9e39-4d73faecab03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f9fc6b6c-c6c4-4ad7-8586-06f5d69b1f33"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Norte/Sul"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0b9a26ff-6a9e-412b-a22e-3df84278e2b6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Norte/Sul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8eca80bd-bbb9-43af-a284-75851d6a1aa4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Norte/Sul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Setas"",
                    ""id"": ""2b0a2a5f-ba49-46a0-8c86-a1b4e740f1c4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Norte/Sul"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""739a5c00-42b2-4df9-b05e-965bece547b6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Norte/Sul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f15a0fd3-948b-4198-b3b1-2b9ae5c3955d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Norte/Sul"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""53d738c3-d2ba-4d9b-9892-d8902c53b3e3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Leste/Oeste"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""25426e09-dae5-4958-87cc-5b9b1952b979"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Leste/Oeste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6aa274b1-3643-4165-9dcf-096d07600df2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Leste/Oeste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Setas"",
                    ""id"": ""76f47b46-132c-47ba-84b0-35e2b8d334e3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Leste/Oeste"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d22ef4f5-5043-405b-a9a4-8df4e0d69dc6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Leste/Oeste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0eab1153-07b6-4e9e-8c5f-a4fa4d02c2cb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Leste/Oeste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""1fbd6263-ab35-46d7-8baa-8c1dd527e97b"",
            ""actions"": [
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""1f2a682d-b5dc-4d77-8e1d-242e71dc4c5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4f784390-e9c0-4883-90eb-8c0122961433"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movimento
        m_Movimento = asset.FindActionMap("Movimento", throwIfNotFound: true);
        m_Movimento_NorteSul = m_Movimento.FindAction("Norte/Sul", throwIfNotFound: true);
        m_Movimento_LesteOeste = m_Movimento.FindAction("Leste/Oeste", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Esc = m_UI.FindAction("Esc", throwIfNotFound: true);
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

    // Movimento
    private readonly InputActionMap m_Movimento;
    private IMovimentoActions m_MovimentoActionsCallbackInterface;
    private readonly InputAction m_Movimento_NorteSul;
    private readonly InputAction m_Movimento_LesteOeste;
    public struct MovimentoActions
    {
        private @PlayerActions m_Wrapper;
        public MovimentoActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @NorteSul => m_Wrapper.m_Movimento_NorteSul;
        public InputAction @LesteOeste => m_Wrapper.m_Movimento_LesteOeste;
        public InputActionMap Get() { return m_Wrapper.m_Movimento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovimentoActions set) { return set.Get(); }
        public void SetCallbacks(IMovimentoActions instance)
        {
            if (m_Wrapper.m_MovimentoActionsCallbackInterface != null)
            {
                @NorteSul.started -= m_Wrapper.m_MovimentoActionsCallbackInterface.OnNorteSul;
                @NorteSul.performed -= m_Wrapper.m_MovimentoActionsCallbackInterface.OnNorteSul;
                @NorteSul.canceled -= m_Wrapper.m_MovimentoActionsCallbackInterface.OnNorteSul;
                @LesteOeste.started -= m_Wrapper.m_MovimentoActionsCallbackInterface.OnLesteOeste;
                @LesteOeste.performed -= m_Wrapper.m_MovimentoActionsCallbackInterface.OnLesteOeste;
                @LesteOeste.canceled -= m_Wrapper.m_MovimentoActionsCallbackInterface.OnLesteOeste;
            }
            m_Wrapper.m_MovimentoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NorteSul.started += instance.OnNorteSul;
                @NorteSul.performed += instance.OnNorteSul;
                @NorteSul.canceled += instance.OnNorteSul;
                @LesteOeste.started += instance.OnLesteOeste;
                @LesteOeste.performed += instance.OnLesteOeste;
                @LesteOeste.canceled += instance.OnLesteOeste;
            }
        }
    }
    public MovimentoActions @Movimento => new MovimentoActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Esc;
    public struct UIActions
    {
        private @PlayerActions m_Wrapper;
        public UIActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Esc => m_Wrapper.m_UI_Esc;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Esc.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEsc;
                @Esc.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEsc;
                @Esc.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEsc;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Esc.started += instance.OnEsc;
                @Esc.performed += instance.OnEsc;
                @Esc.canceled += instance.OnEsc;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IMovimentoActions
    {
        void OnNorteSul(InputAction.CallbackContext context);
        void OnLesteOeste(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnEsc(InputAction.CallbackContext context);
    }
}
