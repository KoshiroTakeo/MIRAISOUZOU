using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCommon
{
    public class StateStay : StateBase
    {
        public override void OnEnter(EnemyCommon owner, StateBase prev)
        {
            Debug.Log("ÉXÉeÉCèÛë‘");
            owner.ChangeState(s_runway);
        }

        public override void OnUpdate(EnemyCommon owner)
        {

        }

        public override void OnFixedUpdate(EnemyCommon owner)
        {

        }

        public override void OnExit(EnemyCommon owner, StateBase next)
        {

        }
    }

}
