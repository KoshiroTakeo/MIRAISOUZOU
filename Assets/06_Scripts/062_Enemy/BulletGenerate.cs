using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
    //�e�v���n�u
    public GameObject BulletObject;
    //�e���ˎ��̃G�t�F�N�g
    public GameObject BulletEffect;
    //���ԊԊu�̍ŏ��l
    public float minTime = 3.0f;
    //���ԊԊu�̍ő�l
    public float maxTime = 5.0f;
    //�eX���W�̍ŏ��l
    public float MinBulletPositionX = -20f;
    //�eX���W�̍ő�l
    public float MaxBulletPositionX = 20f;
    //�e�̃X�s�[�h
    //private float BulletSpeed = 100f;
    //�e�������ԊԊu
    private float interval;
    //�o�ߎ���
    private float time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {

        //���Ԍv��
        time += Time.deltaTime;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (time > interval)
        {
            //�e���C���X�^���X������(��������)
            GameObject bullet = Instantiate(BulletObject);
            //���������e�̈ʒu�������_��(X=-20�`20,Y=0,Z=50)�ɐݒ肷��
            bullet.transform.position = GetRandomPosition();

            //�G�t�F�N�g�𐶐�����
            GameObject effect = Instantiate(BulletEffect) as GameObject;
            //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
            effect.transform.position = bullet.transform.position;

            //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
            time = 0.0f;
            //���ɔ������鎞�ԊԊu�����肷��
            interval = GetRandomTime();

        }
    }

    // �w�肵���͈͂Ń����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //�w�肵���͈͂Ń����_���Ȉʒu�𐶐�����֐�
    private Vector3 GetRandomPosition()
    {
        //X���W�������_���ɐ�������
        float x = Random.Range(MinBulletPositionX, MaxBulletPositionX);
        float y = 0.0f;
        float z = 50.0f;

        //Vector3�^��Position��Ԃ�
        return new Vector3(x, y, z);
    }
}
