using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class EnemyCommon
{
    [SerializeField] GameManager gameMng = null;
    [SerializeField] Rigidbody rig;
    [SerializeField] int life;
    [SerializeField] GameObject weakpoint;
    [SerializeField] GameObject player;
    [SerializeField] private float leave;   // 離れる距離
    [SerializeField] private float idx;     // 指数
    [SerializeField] private float mult;    // 乗数
    [SerializeField] private Animator anim;

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void OnStart()
    {
        Life = life;                    // HPの初期化
        HitWP = false;                  // 弱点表示オフ
        weakpoint.SetActive(false);     
        Invoke(nameof(SetWP), 3.0f);    // Debug3秒後に弱点表示

        // ボスのステート(初期化)
        currentState = s_stay;       // 待機状態から
        currentState.OnEnter(this, null);
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void OnUpdate()
    {
        currentState.OnUpdate(this);
    }

    /// <summary>
    /// 更新処理(Fixed)
    /// </summary>
    private void OnFixedUpdate()
    {
        currentState.OnFixedUpdate(this);
    }

    /// <summary>
    /// 死亡処理
    /// </summary>
    private void OnDeath()
    {
        Debug.Log("DEAD");
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 弱点を表示指せる処理
    /// </summary>
    private void SetWP()
    {
        weakpoint.SetActive(true);
        
        Debug.Log("on");
    }

    private float DistanceCalc()
    {
        float result = 0.0f;

        result = transform.position.z - player.transform.position.z;

        return result;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (HitWP) { return; }

        if (other.gameObject.tag == "Player")
            AddDmg(1);
    }
}