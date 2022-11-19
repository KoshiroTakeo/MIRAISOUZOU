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
            Debug.Log("ÇÁÇÒÇ§Ç•èÛë‘");
        }

        public override void OnUpdate(EnemyCommon owner)
        {
            float dis;
            dis = owner.DistanceCalc();
            if (dis <= 200 && !owner.anim.GetBool("Attack"))
            {
                owner.ChangeState(s_attack);
                owner.anim.SetBool("Attack", true);
            }


        }

        public override void OnFixedUpdate(EnemyCommon owner)
        {
            move = Mathf.Pow(owner.idx, owner.mult) * 0.01f;
            owner.rig.velocity += new Vector3(0, 0, -move);
        }

        public override void OnExit(EnemyCommon owner, StateBase next)
        {
            owner.rig.velocity = new Vector3(0, 0, 0);
        }
    }

}

