using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCommon : MonoBehaviour
{
    /// Instance

    /// Property
    public int Life { get; set; }

    /// Public Var
    public StateBase currentState;  // now

    /// Private Var
    

    /// Public Fnc
    public void AddDmg(int damage)
    {
        Life -= damage;

        if (Life <= 0)
            OnDeath();
    }

    /// Private Fnc
    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }


    /// <summary>
    /// ステートの変更処理
    /// </summary>
    private void ChangeState(StateBase nextState)
    {
        if (currentState != nextState)
        {
            currentState.OnExit(this, nextState);       // 現在のステートの終了処理
            nextState.OnEnter(this, currentState);      // 次のステートの開始処理
            currentState = nextState;                   // 次のステートを現在のステートへ変更処理
        }
    }

}
