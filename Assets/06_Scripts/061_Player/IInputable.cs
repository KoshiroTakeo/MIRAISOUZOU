//======================================================================
// interface IInputable<T>.cs
//======================================================================
// 開発履歴
//
// 2022/11/01 入力プレゼンター
// 
//
//======================================================================
public interface IInputable
{
    // 左コントローラーの操作
    void PressTriggerAction_L();
    void HoldTriggerAction_L(float value);
    void PressGripAction_L();
    void HoldGripAction_L(float value);
    void PressButton_X();
    void PressButton_Y();
    void PressButton_Menu();

    // 右コントローラーの操作
    void PressTriggerAction_R();
    void HoldTriggerAction_R(float value);
    void PressGripAction_R();
    void HoldGripAction_R(float value);
    void PressButton_A();
    void PressButton_B();
    void PressButton_Start();

}
