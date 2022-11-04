using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

#region HeaderComent
//==================================================================================
// Pool
//  オブジェクトプール本体
// 作成日時	:2022/04/24
// 作成者	:前田理玖
//---------- 更新履歴 ----------
// 2021/04/24   つくりはじめたお！
//              
//==================================================================================
#endregion
public class Pool : MonoBehaviour
{
    // Prefabをエディタで指定
    [SerializeField] private PoolableObject pObj;
    [SerializeField] private GameObject stuck;

    // プールのサイズを指定(メモリ節約)
    private const int poolSize = 50;

    // プールの実態   Queueを使用
    public Queue<PoolableObject> qPool = new Queue<PoolableObject>(poolSize);

    // プールにオブジェクトがある場合それを使用。
    // ない場合、新たにInstantiateする
    public T Place<T>(Vector3 pos) where T : PoolableObject
    {
        return (T)Place(pos);
    }

    // プールにオブジェクトがあればそれを利用する。
    public PoolableObject Place(Vector3 pos)
    {
        PoolableObject obj;
        if(qPool.Count > 0)
        {
            obj = qPool.Dequeue();
            obj.gameObject.SetActive(true);
            obj.transform.position = pos;
            obj.OnStart();
        }
        else
        {
            obj = Instantiate(pObj, pos, pObj.transform.rotation);
            obj.pool = this;
            obj.transform.parent = stuck.transform;
            obj.OnStart();
        }
        return obj;
    }

    // オブジェクトをプールに戻す
    public void Return(PoolableObject obj)
    {
        obj.gameObject.SetActive(false);
        qPool.Enqueue(obj);
    }
}
