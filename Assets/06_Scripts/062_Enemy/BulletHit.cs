using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //�e�̃X�s�[�h
    private float BulletSpeed = 0.7f; // 10/20�|���ύX���i���F0.1f�j
    //�Q�[���X�s�[�h
    public float GameSpeed = 1.0f;
    //�v���C���[�X�s�[�h
    public float PlayerSpeed = 1.0f;

    //�e���v���C���[�Ɠ����������̃G�t�F�N�g
    public GameObject HitEffect;
    //�e���������W
    public float BulletDeletePos = -50.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3�Ƃ����^�ɒl�����A�v�Z
        Vector3 BulletPos = transform.position;
        //�e�̑��x�����Z�i�e���x�~�Q�[���X�s�[�h�~�v���C���[�X�s�[�h�j
        BulletPos.z += -BulletSpeed * GameSpeed * PlayerSpeed;
        //�|�W�V�����ɑ��
        transform.position = BulletPos;

        //�e��Z���̈ʒu��BulletDeletePos�ȉ��̎�
        if (gameObject.transform.position.z < BulletDeletePos)
        {
            //�e���폜
            Destroy(gameObject);
        }
    }

    // �����蔻��
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
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

            Debug.Log("�a�ꂽ");

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
