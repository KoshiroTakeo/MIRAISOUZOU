//============================================================
// シーン上のプレイヤー
//======================================================================
// 開発履歴
// 20220728:可用性向上のため再構築
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class MasterPlayer : MonoBehaviour
    {
        // 各クラス必要コンポーネント（Unity依存）
        CharacterController PlayerCharacter; 

        GameObject AnchorObject;                     // 浮遊移動用
        [SerializeField] GameObject CenterEyeAnchor; // カメラ（HMD本体）
        Vector3 InitirizeAnchorPos = new Vector3();

        // Playerのパラメータデータ
        [SerializeField] PlayerData Data; // スクリプタブル
        [SerializeField] PlayerParameter Parameter;

        // 移動クラス
        HoverMover HoverMove;  // 浮遊移動

        // ゲームマネージャー
        GameManager Manager;


       

        private void Start()
        {
            PlayerCharacter = GetComponent<CharacterController>();

            AnchorObject = new GameObject("AnchorObject");
            AnchorObject.transform.position = this.gameObject.transform.position;
            MoveAnchor moveAnchor = new MoveAnchor(CenterEyeAnchor, this.gameObject);
            moveAnchor = AnchorObject.AddComponent<MoveAnchor>();

            moveAnchor.Centereye = CenterEyeAnchor;
            moveAnchor.PlayerObj = this.gameObject;
            Debug.Log(moveAnchor.Centereye);


            Parameter = new PlayerParameter(Data);
            HoverMove = new HoverMover();

            Manager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        }

        private void Update()
        {
            // 死亡したらこれより先実行しない
            if (Parameter.bDeath)
            {
                Manager.OnGameOver();
                return;
            }

            // 浮遊移動
            HoverMove.HeadInclinationMove(this.gameObject ,PlayerCharacter, AnchorObject.transform.position, InitirizeAnchorPos,Parameter.fSpeed);
        }

        // 各ボタン押したら起こる事たち
        public void SkillAction()
        {
            Manager.OnSkill();
        }

        public void MenuAction()
        {

        }



        // 接触判定
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "EnemyAttack")
            {
                StartCoroutine(Parameter.OnArmorTime());
                Manager.CheckDamage();
                Parameter.CheckHP();
            }

        }

        
        
    }
}

