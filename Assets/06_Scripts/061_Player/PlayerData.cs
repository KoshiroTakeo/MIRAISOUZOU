//============================================================
// プレイヤーデータのスクリタブルデータ
//======================================================================
// 開発履歴
// 20220729:可用性向上のため再構築
//======================================================================
using UnityEngine;

namespace VR.Players
{
    // いずれテキストデータに
    [CreateAssetMenu(menuName = "Scriptable/New Create PlayerData")]
    public class PlayerData : ScriptableObject
    {
        // 各パラメータ
        public int nHP = 5;
        public float fSpeed = 1;
        public float fArmorTime = 0.8f;
        public float fSkillTime = 3.0f;

    }
}
