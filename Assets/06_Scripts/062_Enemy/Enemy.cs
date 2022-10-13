using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCommon
{
    [SerializeField] int life;
    [SerializeField] GameObject weakpoint;

    /// <summary>
    /// ����������
    /// </summary>
    private void OnStart()
    {
        Life = life;
        HitWP = false;
        weakpoint.SetActive(false);
        Invoke(nameof(Fnc), 3.0f);
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    private void OnUpdate()
    {
        
    }

    /// <summary>
    /// �X�V����(Fixed)
    /// </summary>
    private void OnFixedUpdate()
    {

    }

    /// <summary>
    /// ���S����
    /// </summary>
    private void OnDeath()
    {
        Debug.Log("DEAD");
        gameObject.SetActive(false);
    }

    private void Fnc()
    {
        weakpoint.SetActive(true);
        Debug.Log("on");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (HitWP) { return; }

        if (other.gameObject.tag == "Player")
            AddDmg(1);
    }
}