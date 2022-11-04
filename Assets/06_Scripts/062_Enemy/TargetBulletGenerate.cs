using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulletGenerate : MonoBehaviour
{
    //�e�v���n�u
    public GameObject TbulletObject;
    //�e���ˎ��̃G�t�F�N�g
    public GameObject TbulletEffect;
    //�v���C���[�̃v���n�u
    public GameObject Player;
    //�G�̃v���n�u
    public GameObject TEnemy;
    //���ԊԊu�̍ŏ��l
    public float minTime = 3.0f;
    //���ԊԊu�̍ő�l
    public float maxTime = 5.0f;
    //�e�������ԊԊu
    private float Hinterval;
    //�o�ߎ���
    private float Htime = 0.0f;
    //�v���C���[�ƓG�̋���
    private float distance;
    //�e���~�߂鎞�̋���
    public float BulletStop = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        Hinterval = GetRandomTime();

        //�I�u�W�F�N�g��������
        Player = GameObject.Find("Player");
        TEnemy = GameObject.Find("TargetEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍv��
        Htime += Time.deltaTime;

        //�v���C���[�̕���������
        transform.LookAt(Player.transform);

        //�v���C���[�ƓG�̈ʒu
        distance = TEnemy.transform.position.z - Player.transform.position.z;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (Htime > Hinterval)
        {
            if (distance > BulletStop)
            {
                //�e���C���X�^���X������(��������)
                GameObject Hbullet = Instantiate(TbulletObject);
                //���������e�̈ʒu�������_��(X=-20�`20,Y=0,Z=50)�ɐݒ肷��
                Hbullet.transform.position = TEnemy.transform.position;

                //�G�t�F�N�g�𐶐�����
                GameObject effect = Instantiate(TbulletEffect) as GameObject;
                //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
                effect.transform.position = Hbullet.transform.position;

                //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
                Htime = 0.0f;
                //���ɔ������鎞�ԊԊu�����肷��
                Hinterval = GetRandomTime();
            }

        }
    }
    // �w�肵���͈͂Ń����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }
}
