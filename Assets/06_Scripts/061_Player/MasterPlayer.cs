//============================================================
// �V�[����̃v���C���[
//======================================================================
// �J������
// 20220728:�p������̂��ߍč\�z
//======================================================================
using UnityEngine;
using UnityEngine.InputSystem;

namespace VR.Players
{
    public class MasterPlayer : MonoBehaviour//,IInputable
    {
        // �e�N���X�K�v�R���|�[�l���g�iUnity�ˑ��j
        CharacterController PlayerCharacter; 

        GameObject AnchorObject;                     // ���V�ړ��p
        [SerializeField] GameObject CenterEyeAnchor; // �J�����iHMD�{�́j
        Vector3 InitirizeAnchorPos = new Vector3();

        // Player�̃p�����[�^�f�[�^
        [SerializeField] PlayerData Data; // �X�N���v�^�u��
        [SerializeField] PlayerParameter Parameter;

        // �ړ��N���X
        HoverMover HoverMove;  // ���V�ړ�

        // �Q�[���}�l�[�W���[
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
            // ���S�����炱�������s���Ȃ�
            if (Parameter.bDeath)
            {
                Manager.OnGameOver();
                return;
            }

            // ���V�ړ�
            HoverMove.HeadInclinationMove(this.gameObject ,PlayerCharacter, AnchorObject.transform.position, InitirizeAnchorPos,Parameter.fSpeed);
        }

        // ���R���g���[���[����
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

        // �E�R���g���[���[����
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

        // �ڐG����
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

