using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletGenerate : MonoBehaviour
{
    //�e�v���n�u
    public GameObject HbulletObject;
    //�e���ˎ��̃G�t�F�N�g
    public GameObject HbulletEffect;
    //�v���C���[�̃v���n�u
    public GameObject Player;
    //�G�̃v���n�u
    public GameObject Enemy;
    //���ԊԊu�̍ŏ��l
    public float minTime = 3.0f;
    //���ԊԊu�̍ő�l
    public float maxTime = 5.0f;
    //�e�������ԊԊu
    private float Hitinterval;
    //�o�ߎ���
    private float Hittime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        Hitinterval = GetRandomTime();

        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("HomingEnemy");
    }

    // Update is called once per frame
    void Update()
    {

        //���Ԍv��
        Hittime += Time.deltaTime;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (Hittime > Hitinterval)
        {
            //�e���C���X�^���X������(��������)
            GameObject Hitbullet = Instantiate(HbulletObject);
            //���������e�̈ʒu�������_��(X=-20�`20,Y=0,Z=50)�ɐݒ肷��
            Hitbullet.transform.position = Enemy.transform.position;
            //�v���C���[�̕���������
            transform.LookAt(Player.transform);

            //�G�t�F�N�g�𐶐�����
            GameObject effect = Instantiate(HbulletEffect) as GameObject;
            //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
            effect.transform.position = Hitbullet.transform.position;
            //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
            Hittime = 0.0f;
            //���ɔ������鎞�ԊԊu�����肷��
            Hitinterval = GetRandomTime();

        }
    }

    // �w�肵���͈͂Ń����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

}
