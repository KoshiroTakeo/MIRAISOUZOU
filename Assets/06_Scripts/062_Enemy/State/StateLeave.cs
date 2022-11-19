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
            target = pos.z - owner.leave;
            check = pos;
            //DelayStateChange(owner);
        }

        public override void OnUpdate(EnemyCommon owner)
        {
            if (owner.transform.position.z > 500)
                owner.ChangeState(s_runway);
        }

        public override void OnFixedUpdate(EnemyCommon owner)
        {
            pos.z = Mathf.SmoothDamp(pos.z, -target, ref currentvelocity, 1f);
            owner.transform.position = pos;
        }

        public override void OnExit(EnemyCommon owner, StateBase next)
        {
            owner.rig.velocity = Vector3.zero;
        }

        private IEnumerator DelayStateChange(EnemyCommon owner)
        {
            yield return new WaitForSeconds(1.5f);

            owner.ChangeState(s_runway);
        }
    }

}

