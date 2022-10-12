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
    /// �X�e�[�g�̕ύX����
    /// </summary>
    private void ChangeState(StateBase nextState)
    {
        if (currentState != nextState)
        {
            currentState.OnExit(this, nextState);       // ���݂̃X�e�[�g�̏I������
            nextState.OnEnter(this, currentState);      // ���̃X�e�[�g�̊J�n����
            currentState = nextState;                   // ���̃X�e�[�g�����݂̃X�e�[�g�֕ύX����
        }
    }

}
