using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMove : MonoBehaviour
{
    //�t�B�[���h�ړ����x
    public float Field_Speed = 0;

    //�t�B�[���h�Đݒu�ʒu�I�u�W�F�N�g
<<<<<<< HEAD
    private GameObject Pop_Point;
=======
<<<<<<< HEAD
    public GameObject Pop_Point;
=======
    private GameObject Pop_Point;
>>>>>>> kama
>>>>>>> origin/master

    //GemeManager�̕ϐ������Ă���p
    private GameManager GameMng;

    private void Start()
    {
        Pop_Point = GameObject.Find("FieldPopPoint");

        GameMng = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        Vector3 Field_Pos = transform.position;
        //�t�B�[���h�̈ړ����s
<<<<<<< HEAD
        Vector3 Field_Pos = transform.position;

=======
=======
        //�t�B�[���h�̈ړ����s
        Vector3 Field_Pos = transform.position;

>>>>>>> kama
>>>>>>> origin/master
        Field_Pos.z -= Time.deltaTime * Field_Speed * GameMng.WorldTime * GameMng.AccelSpeed;

        transform.position = Field_Pos;

        if (transform.position.z <= -5.0f)
        {
            transform.position = Pop_Point.transform.position;
        }
    }

    //�v���C���[�_���[�W������
    public void PlayerDamage()
    {
        Field_Speed = Field_Speed - 1.0f;
    }
}