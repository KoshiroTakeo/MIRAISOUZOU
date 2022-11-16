<<<<<<< HEAD
//============================================================
// InputManager.cs
//======================================================================
// 開発履歴
//
// 2022/10/29 
// 2022/11/04 何かした
//
//======================================================================
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using VR.Players;

public class InputManager : MonoBehaviour
{
    IInputable InputPlayer;
    [SerializeField] float fHoldValue = 0.7f;

    [Header("<<左コントローラーの入力>>")]
    [Header("トリガー")] public InputActionProperty TriggerAction_L;
    [Header("グリップ")] public InputActionProperty GripAction_L;
    [Header("Xボタン")] public InputActionProperty ButtonAction_X;
    [Header("Yボタン")] public InputActionProperty ButtonAction_Y;
    [Header("メニューボタン")] public InputActionProperty ButtonAction_Menu;

    [Header("<<右コントローラーの入力>>")]
    [Header("トリガー")] public InputActionProperty TriggerAction_R;
    [Header("グリップ")] public InputActionProperty GripAction_R;
    [Header("Aボタン")] public InputActionProperty ButtonAction_A;
    [Header("Bボタン")] public InputActionProperty ButtonAction_B;
    [Header("スタートボタン")] public InputActionProperty ButtonAction_Start;

    void Start()
    {
        InputPlayer = this.gameObject.GetComponent<IInputable>();
        if (this.gameObject.GetComponent<MasterPlayer>() == null)
        {
            Debug.Log("MasterPlayer をアタッチしてください");
        }

        if (this.gameObject.GetComponent<InputActionManager>() == null)
        {
            Debug.Log("InputActionManager をアタッチしてください");
        }
    }



    void Update()
    {
        // 各入力の値を取得
        float triggervalue_L = TriggerAction_L.action.ReadValue<float>();
        bool triggerpress_L = TriggerAction_L.action.IsPressed();
        float triggervalue_R = TriggerAction_R.action.ReadValue<float>();
        bool triggerpress_R = TriggerAction_R.action.IsPressed();
        float gripvalue_L = GripAction_L.action.ReadValue<float>();
        bool grippress_L = GripAction_L.action.IsPressed();
        float gripvalue_R = GripAction_R.action.ReadValue<float>();
        bool grippress_R = GripAction_R.action.IsPressed();
        bool button_A = ButtonAction_A.action.triggered;
        bool button_B = ButtonAction_B.action.triggered;
        bool button_X = ButtonAction_X.action.triggered;
        bool button_Y = ButtonAction_Y.action.triggered;
        bool button_Menu = ButtonAction_Menu.action.triggered;
        bool button_Start = ButtonAction_Start.action.triggered;

        InputTrigger_L(triggervalue_L, triggerpress_L);
        InputTrigger_R(triggervalue_R, triggerpress_R);
        InputGrip_L(gripvalue_L, grippress_L);
        InputGrip_L(gripvalue_R, grippress_R);

        InputButton_A(button_A);
        InputButton_B(button_B);
        InputButton_X(button_X);
        InputButton_Y(button_Y);
        InputButton_Menu(button_Menu);
        InputButton_Start(button_Start);

    }

    public void InputTrigger_L(float _value, bool _press)
    {
        if (_value >= fHoldValue) InputPlayer.HoldTriggerAction_L(_value);
        if (_press == true) InputPlayer.PressTriggerAction_L();

    }
    public void InputTrigger_R(float _value, bool _press)
    {
        if (_value >= fHoldValue) InputPlayer.HoldTriggerAction_R(_value);
        if (_press == true) InputPlayer.PressTriggerAction_R();
    }
    public void InputGrip_L(float _value, bool _press)
    {
        if (_value <= fHoldValue) InputPlayer.HoldGripAction_L(_value); ;
        if (_press == true) InputPlayer.PressGripAction_L();

    }
    public void InputGrip_R(float _value, bool _press)
    {
        if (_value <= fHoldValue) InputPlayer.HoldGripAction_R(_value); ;
        if (_press == true) InputPlayer.PressGripAction_R();

    }
    public void InputButton_A(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_A();
    }
    public void InputButton_B(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_B();
    }
    public void InputButton_X(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_X();
    }
    public void InputButton_Y(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_Y();
    }
    public void InputButton_Menu(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_Menu();
    }
    public void InputButton_Start(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_Start();
    }

}
=======
//============================================================
// InputManager.cs
//======================================================================
// 開発履歴
//
// 2022/10/29 
// 2022/11/04 何かした
//
//======================================================================
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using VR.Players;

public class InputManager : MonoBehaviour
{
    IInputable InputPlayer;
    [SerializeField] float fHoldValue = 0.7f;

    [Header("<<左コントローラーの入力>>")]
    [Header("トリガー")] public InputActionProperty TriggerAction_L;
    [Header("グリップ")] public InputActionProperty GripAction_L;
    [Header("Xボタン")] public InputActionProperty ButtonAction_X;
    [Header("Yボタン")] public InputActionProperty ButtonAction_Y;
    [Header("メニューボタン")] public InputActionProperty ButtonAction_Menu;

    [Header("<<右コントローラーの入力>>")]
    [Header("トリガー")] public InputActionProperty TriggerAction_R;
    [Header("グリップ")] public InputActionProperty GripAction_R;
    [Header("Aボタン")] public InputActionProperty ButtonAction_A;
    [Header("Bボタン")] public InputActionProperty ButtonAction_B;
    [Header("スタートボタン")] public InputActionProperty ButtonAction_Start;

    void Start()
    {
        InputPlayer = this.gameObject.GetComponent<IInputable>();
        if (this.gameObject.GetComponent<MasterPlayer>() == null)
        {
            Debug.Log("MasterPlayer をアタッチしてください");
        }

        if (this.gameObject.GetComponent<InputActionManager>() == null)
        {
            Debug.Log("InputActionManager をアタッチしてください");
        }
    }



    void Update()
    {
        // 各入力の値を取得
        float triggervalue_L = TriggerAction_L.action.ReadValue<float>();
        bool triggerpress_L = TriggerAction_L.action.IsPressed();
        float triggervalue_R = TriggerAction_R.action.ReadValue<float>();
        bool triggerpress_R = TriggerAction_R.action.IsPressed();
        float gripvalue_L = GripAction_L.action.ReadValue<float>();
        bool grippress_L = GripAction_L.action.IsPressed();
        float gripvalue_R = GripAction_R.action.ReadValue<float>();
        bool grippress_R = GripAction_R.action.IsPressed();
        bool button_A = ButtonAction_A.action.triggered;
        bool button_B = ButtonAction_B.action.triggered;
        bool button_X = ButtonAction_X.action.triggered;
        bool button_Y = ButtonAction_Y.action.triggered;
        bool button_Menu = ButtonAction_Menu.action.triggered;
        bool button_Start = ButtonAction_Start.action.triggered;

        InputTrigger_L(triggervalue_L, triggerpress_L);
        InputTrigger_R(triggervalue_R, triggerpress_R);
        InputGrip_L(gripvalue_L, grippress_L);
        InputGrip_L(gripvalue_R, grippress_R);

        InputButton_A(button_A);
        InputButton_B(button_B);
        InputButton_X(button_X);
        InputButton_Y(button_Y);
        InputButton_Menu(button_Menu);
        InputButton_Start(button_Start);

    }

    public void InputTrigger_L(float _value, bool _press)
    {
        if (_value >= fHoldValue) InputPlayer.HoldTriggerAction_L(_value);
        if(_press == true)InputPlayer.PressTriggerAction_L();
        
    }
    public void InputTrigger_R(float _value, bool _press)
    {
        if (_value >= fHoldValue) InputPlayer.HoldTriggerAction_R(_value);
        if (_press == true) InputPlayer.PressTriggerAction_R();
    }
    public void InputGrip_L(float _value, bool _press)
    {
        if (_value <= fHoldValue) InputPlayer.HoldGripAction_L(_value); ;
        if (_press == true) InputPlayer.PressGripAction_L();
        
    }
    public void InputGrip_R(float _value, bool _press)
    {
        if (_value <= fHoldValue) InputPlayer.HoldGripAction_R(_value); ;
        if (_press == true) InputPlayer.PressGripAction_R();
        
    }
    public void InputButton_A(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_A();
    }
    public void InputButton_B(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_B();
    }
    public void InputButton_X(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_X();
    }
    public void InputButton_Y(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_Y();
    }
    public void InputButton_Menu(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_Menu();
    }
    public void InputButton_Start(bool _on)
    {
        if (_on == false) return;
        InputPlayer.PressButton_Start();
    }

}
>>>>>>> kama
