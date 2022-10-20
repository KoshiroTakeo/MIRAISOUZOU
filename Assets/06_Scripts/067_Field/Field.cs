using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    int StageSize = 20;
    int StageIndex;

    public Transform Target;//�v���C���[�L�����N�^�[
    public GameObject[] stagenum;//�X�e�[�W�̃v���n�u
    public int FirstStageIndex;//�X�^�[�g���ɂǂ̃C���f�b�N�X����X�e�[�W�𐶐�����̂�
    public int aheadStage; //���O�ɐ������Ă����X�e�[�W
    public List<GameObject> StageList = new List<GameObject>();//���������X�e�[�W�̃��X�g

    int count = 0;
    //public GameObject Target_Check;

    //private GameObject Field_Check; 

    // Start is called before the first frame update
    void Start()
    {
        StageIndex = FirstStageIndex;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.z / StageSize);

        if (StageList[25].gameObject.transform.position.z <= -20/*targetPosIndex + aheadStage > StageIndex*/)
        {
            StageManager(targetPosIndex + /*(int)StageList[49].gameObject.transform.position.z*/ + aheadStage);
        }
    }
    void StageManager(int maps)
    {
        //Debug.Log("aaaa");
        if (maps <= StageIndex)
        {
            StageIndex = 0;
            return;
        }

        for (int i = StageIndex + 1; i <= maps; i++)//�w�肵���X�e�[�W�܂ō쐬����
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 1)//�Â��X�e�[�W���폜����
        {
            Debug.Log("delete");
            DestroyStage();
        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)//�X�e�[�W�𐶐�����
    {
        int nextStage = Random.Range(0, stagenum.Length);

        GameObject stageObject = (GameObject)Instantiate(stagenum[nextStage], new Vector3(0, -10, index * StageSize), Quaternion.identity);

        return stageObject;
    }

    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);
    }

    //private void OnTriggerEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Field_Check"))
    //    {
    //        count++;
    //        if (count >= 5)
    //        {
    //            StageManager((int)StageList[5].gameObject.transform.position.z + 
    //                         (int)StageList[5].gameObject.transform.position.z / 2 + count);

    //            for (int i = 0; i >= count; i++) 
    //            {
    //                DestroyStage();
    //            }
    //            count = 0;
    //        }
    //        Debug.Log("att");
    //        //StageManager(10 + aheadStage);
    //    }
    //}

}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Field : MonoBehaviour
//{
//    //int�^��ϐ�StageTipSize�Ő錾���܂��B
//    const int StageTipSize = 30;
//    //int�^��ϐ�currentTipIndex�Ő錾���܂��B
//    int currentTipIndex;
//    //�^�[�Q�b�g�L�����N�^�[�̎w�肪�o����l�ɂ����
//    public Transform character;
//    //�X�e�[�W�`�b�v�̔z��
//    public GameObject[] stageTips;
//    //�����������鎞�Ɏg���ϐ�startTipIndex
//    public int startTipIndex;
//    //�X�e�[�W�����̐�ǂ݌�
//    public int preInstantiate;
//    //������X�e�[�W�`�b�v�̕ێ����X�g
//    public List<GameObject> generatedStageList = new List<GameObject>();

//    void Start()
//    {
//        //����������
//        currentTipIndex = startTipIndex - 1;
//        UpdateStage(preInstantiate);
//    }


//    void Update()
//    {
//        //�L�����N�^�[�̈ʒu���猻�݂̃X�e�[�W�`�b�v�̃C���f�b�N�X���v�Z���܂�
//        int charaPositionIndex = (int)(character.position.z / StageTipSize);
//        //���̃X�e�[�W�`�b�v�ɓ�������X�e�[�W�̍X�V�������s���܂��B
//        if (charaPositionIndex + preInstantiate > currentTipIndex)
//        {
//            UpdateStage(charaPositionIndex + preInstantiate);
//        }

//    }
//    //�w��̃C���f�b�N�X�܂ł̃X�e�[�W�`�b�v�𐶐����āA�Ǘ����ɂ���
//    void UpdateStage(int toTipIndex)
//    {
//        if (toTipIndex <= currentTipIndex) return;
//        //�w��̃X�e�[�W�`�b�v�܂Ő��������
//        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
//        {
//            GameObject stageObject = GenerateStage(i);
//            //���������X�e�[�W�`�b�v���Ǘ����X�g�ɒǉ����āA
//            generatedStageList.Add(stageObject);
//        }
//        //�X�e�[�W�ێ�����ɂȂ�܂ŌÂ��X�e�[�W���폜���܂��B
//        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

//        currentTipIndex = toTipIndex;
//    }
//    //�w��̃C���f�b�N�X�ʒu��stage�I�u�W�F�N�g�������_���ɐ���
//    GameObject GenerateStage(int tipIndex)
//    {
//        int nextStageTip = Random.Range(0, stageTips.Length);

//        GameObject stageObject = (GameObject)Instantiate(
//            stageTips[nextStageTip],
//            new Vector3(0, 0, tipIndex * StageTipSize),
//            Quaternion.identity);
//        return stageObject;
//    }
//    //��ԌÂ��X�e�[�W���폜���܂�
//    void DestroyOldestStage()
//    {
//        GameObject oldStage = generatedStageList[0];
//        generatedStageList.RemoveAt(0);
//        Destroy(oldStage);
//    }

//}