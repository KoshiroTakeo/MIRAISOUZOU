//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KeyMoveTest : MonoBehaviour
//{

//    //�L�����N�^�[�̑����Ԃ��Ǘ�����t���O
//    [SerializeField] public bool onGround = true;
//    [SerializeField] public bool inJumping = false;

//    public bool PlayerDamage = false;//�v���C���[�_���[�W����

//    //rigidbody�I�u�W�F�N�g�i�[�p�ϐ�
//    Rigidbody rb;

//    //�ړ����x�̒�`
//    public float Speed = 0f;

//    //�_���[�W���ړ����x�̒�`
//    public float Damage_Speed = 0f;

//    //�ړ��̌W���i�[�p�ϐ�
//    float v;

//    void Update() //20220429 Start����Update�֒���
//    {
//        if (PlayerDamage == false)
//        {
//            v = Time.deltaTime * Speed;

//            //�ړ��̎��s
//            if (!inJumping)//�󒆂ł̈ړ����֎~
//            {
//                transform.position += transform.forward * v;
//            }

//        }
//        else if (PlayerDamage == true)
//        {
//            v = /*Time.deltaTime **/ Damage_Speed;
//            transform.position += transform.forward * v;
//        }
//    }

//    public void PlayerDamage()
//    {

//    }
//}
