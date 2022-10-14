#region HeaderComent
//==================================================================================
// StateBase
// 敵のステートの基底クラス
// 作成日時	:2022/10/7
// 作成者	:前田理玖
//---------- 更新履歴 ----------
// 2022/10/7   つくりはじめ
//==================================================================================
#endregion

public abstract class StateBase
{
    /// <summary>
    /// 開始時に呼ばれる
    /// </summary>
    public virtual void OnEnter(EnemyCommon owner, StateBase prev) {}

    /// <summary>
    /// 更新時に呼ばれる
    /// </summary>
    public virtual void OnUpdate(EnemyCommon owner) { }

    /// <summary>
    /// 更新時(fixed)に呼ばれる
    /// </summary>
    public virtual void OnFixedUpdate(EnemyCommon owner) { }

    /// <summary>
    /// 終了時に呼ばれる
    /// </summary>
    public virtual void OnExit(EnemyCommon owner, StateBase next) { }
}
