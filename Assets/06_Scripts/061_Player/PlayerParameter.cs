//============================================================
// プレイヤーの能力値
//======================================================================
// 開発履歴
// 20220729:可用性向上のため再構築
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR.Players
{
    public class PlayerParameter
    {
        // 各パラメータ
        public int nHP;
        int nMaxHP;
        int nCurrentHP;
        public float fSpeed = 1;

        // 死亡判定
        public bool bDeath = false;

        // 無敵時間
        public WaitForSeconds WTSArmorTime;
        public bool bOnDamage = false;

        // スラッシュタイム
        public bool bSkill = false;
        float fSkillTime;



        public PlayerParameter(PlayerData _data)
        {
            nMaxHP = nCurrentHP = nHP = _data.nHP;
            fSpeed = _data.fSpeed;
            fSkillTime = _data.fSkillTime;
            WTSArmorTime = new WaitForSeconds(_data.fArmorTime);

        }

        public void CheckHP()
        {
           
            if (nHP <= 0)
            {
                bDeath = true;
            }

        }

        public IEnumerator OnArmorTime()
        {

            if (bOnDamage == true) yield return 0;
            bOnDamage = true;
            nHP--;

            yield return WTSArmorTime;

            bOnDamage = false;
        }
    }
}
