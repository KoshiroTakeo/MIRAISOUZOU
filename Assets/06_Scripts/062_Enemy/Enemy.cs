using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCommon
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    private void OnStart()
    {

    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void OnUpdate()
    {

    }

    /// <summary>
    /// 更新処理(Fixed)
    /// </summary>
    private void OnFixedUpdate()
    {

    }

    /// <summary>
    /// 死亡処理
    /// </summary>
    private void OnDeath()
    {
        gameObject.SetActive(false);
    }
}