using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCommon
{
    public class StateRunway : StateBase
    {
        private float move;

        public override void OnEnter(EnemyCommon owner, StateBase prev)
        {
            Debug.Log("‚ç‚ñ‚¤‚¥ó‘Ô");
        }

        public override void OnUpdate(EnemyCommon owner)
        {
            //if (owner.transform.position.x >= 10)
            //    owner.ChangeState(s_leave);
            
            move = Mathf.Pow(owner.idx, owner.mult) * 0.01f;
            owner.rig.velocity += new Vector3(0, 0, -move);
        }

        public override void OnFixedUpdate(EnemyCommon owner)
        {
            
        }

        public override void OnExit(EnemyCommon owner, StateBase next)
        {
            
        }
    }

}

