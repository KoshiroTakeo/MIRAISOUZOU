using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCommon
{
    public class StateLeave : StateBase
    {
        Vector3 pos;        // 現在地
        float target;       // 目的地    一軸のみ
        float currentvelocity = 0;
        Vector3 check;
        


        public override void OnEnter(EnemyCommon owner, StateBase prev)
        {
            Debug.Log("にーげるんダヨーン");
            pos = owner.transform.position;
            currentvelocity = owner.rig.velocity.magnitude;
            target = pos.x - owner.leave;
            check = pos;
        }

        public override void OnUpdate(EnemyCommon owner)
        {
            //if (Mathf.Abs(target - pos.x) > 0.1)
            //    owner.ChangeState(s_runway);

            pos.x = Mathf.SmoothDamp(pos.x, target, ref currentvelocity, 0.8f, 5);
            owner.transform.position = pos;

            
        }

        public override void OnFixedUpdate(EnemyCommon owner)
        {

        }

        public override void OnExit(EnemyCommon owner, StateBase next)
        {

        }
    }

}

