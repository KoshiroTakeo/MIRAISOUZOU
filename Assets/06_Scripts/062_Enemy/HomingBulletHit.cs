using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletHit : MonoBehaviour
{
    //�e�̃X�s�[�h
    public float BulletSpeed = 0.01f;
    //�Q�[���X�s�[�h
    public float GameSpeed = 1.0f;
    //�v���C���[�X�s�[�h
    public float PlayerSpeed = 1.0f;
    //�e���v���C���[�Ɠ����������̃G�t�F�N�g
    public GameObject HitEffect;
    //�v���C���[�v���n�u
    public GameObject Player;
    //�G�l�~�[�v���n�u
    public GameObject Enemy;
    //�e���������W
    public float BulletDeletePos = -50.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("HomingEnemy");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, BulletSpeed * GameSpeed * PlayerSpeed);

        //�e��Z���̈ʒu��BulletDeletePos�ȉ��̎�
        if (gameObject.transform.position.z < BulletDeletePos)
        {
            //�e���폜
            Destroy(gameObject);
        }
    }

    // �����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        //�Փ˂����I�u�W�F�N�g��Player�������Ƃ�
        if (collision.gameObject.CompareTag("Player"))
        {
            //�e���폜
            Destroy(gameObject);

            //�G�t�F�N�g�𔭐�������
            //GenerateHitEffect();
        }
        
        //�Փ˂����I�u�W�F�N�g��Player�������Ƃ�
        if (collision.gameObject.CompareTag("Weapon"))
        {
            //�e���폜
            Destroy(gameObject);

            //�G�t�F�N�g�𔭐�������
            //GenerateHitEffect();
        }
        
    }
    void GenerateHitEffect()
    {
        //�G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(HitEffect) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
        effect.transform.position = gameObject.transform.position;
    }
}
