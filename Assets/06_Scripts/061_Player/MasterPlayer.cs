//============================================================
// シーン上のプレイヤー
//======================================================================
// 開発履歴
// 20220728:可用性向上のため再構築
//======================================================================
using UnityEngine;
using UnityEngine.InputSystem;

namespace VR.Players
{
    public class MasterPlayer : MonoBehaviour//,IInputable
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

        // 左コントローラー処理
        public void PressTriggerAction_L()
        {
            
        }
        public void HoldTriggerAction_L(float value)
        {

        }

        public void PressGripAction_L()
        {

        }

        public void HoldGripAction_L(float value)
        {

        }

        public void PressButton_X()
        {
            
        }

        public void PressButton_Y()
        {
           
        }

        public void PressButton_Menu()
        {

        }

        // 右コントローラー処理
        public void PressTriggerAction_R()
        {
            
        }

        public void HoldTriggerAction_R(float value)
        {

        }

        public void PressGripAction_R()
        {

        }

        public void HoldGripAction_R(float value)
        {

        }

        public void PressButton_A()
        {
            
        }

        public void PressButton_B()
        {
            
        }

        public void PressButton_Start()
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

