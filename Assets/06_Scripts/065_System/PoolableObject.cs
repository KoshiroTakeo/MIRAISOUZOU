using UnityEngine;

#region HeaderComent
//==================================================================================
// PoolableObject
//	プールする為のオブジェクトの継承用
// 作成日時	:2022/04/24
// 作成者	:前田理玖
//---------- 更新履歴 ----------
// 2021/04/24   つくりはじめたお！
//              
//==================================================================================
#endregion
public abstract class PoolableObject : MonoBehaviour
{
    // プールへの参照
    public Pool pool{ private get; set; }

    // Start()の代わり
    public abstract void OnStart();

    // プールに戻す
    protected void ReturnToPool()
    {
        pool.Return(this);
    }
}
