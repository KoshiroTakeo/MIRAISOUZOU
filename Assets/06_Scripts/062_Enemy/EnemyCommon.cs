using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCommon : MonoBehaviour
{
    /// Instance

    /// Property
    public int Life { get; set; }   // Hit point
    public bool HitWP { get; set; } // 弱点に当たったかどうか

    /// Public Var
    public StateBase currentState;  // now

    /// Private Var
    private static readonly StateStay s_stay = new StateStay();
    private static readonly StateRunway s_runway = new StateRunway();
    private static readonly StateChangemode s_changemode = new StateChangemode();
    private static readonly StateLeave s_leave = new StateLeave();
    private static readonly StateAttack s_attack = new StateAttack();

    /// Public Fnc
    public void AddDmg(int damage)
    {
        Life -= damage;

        Debug.Log("Now Hp" + Life );
        if (Life <= 0)
            OnDeath();
    }

    public void PlayerDamage()
    {
        // 10遠ざかる
        ChangeState(s_leave);
    }

    public void OnLeave()
    {
        ChangeState(s_leave);
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
