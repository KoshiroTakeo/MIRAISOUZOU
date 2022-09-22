//============================================================
// �V�[����̃v���C���[
//======================================================================
// �J������
// 20220728:�p������̂��ߍč\�z
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class MasterPlayer : MonoBehaviour
    {
        // �e�N���X�K�v�R���|�[�l���g�iUnity�ˑ��j
        CharacterController PlayerCharacter; 

        GameObject AnchorObject;                     // ���V�ړ��p
        [SerializeField] GameObject CenterEyeAnchor; // �J�����iHMD�{�́j
        Vector3 InitirizeAnchorPos = new Vector3();

        // Player�̃p�����[�^�f�[�^
        [SerializeField] PlayerData Data; // �X�N���v�^�u��
        PlayerParameter Parameter;

        // �ړ��N���X
        StickMover NormalMove; // �A�i���O�X�e�B�b�N�ɂ��ړ�
        HoverMover HoverMove;  // ���V�ړ�

        // �U���N���X

        // �G�t�F�N�g�N���X


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
            NormalMove = new StickMover();
            HoverMove = new HoverMover();

            
        }

        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                // ���݈ʒu�����_�Ƃ��A�ړ��J�n�̒n�_�Ƃ���
                InitirizeAnchorPos = AnchorObject.transform.position;
            }

            // ���V�ړ�
            HoverMove.HeadInclinationMove(this.gameObject ,PlayerCharacter, AnchorObject.transform.position, InitirizeAnchorPos,Parameter.fSpeed);
        }

        private void LateUpdate()
        {
            
        }
    }
}

