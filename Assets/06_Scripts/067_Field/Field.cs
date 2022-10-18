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

        //Target_Check = GameObject.Find("Wall_F");

        //Field_Check = GameObject.Find("Field_Check");
    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.z /*StageSize*/);

        if (StageList[9].gameObject.transform.position.z <= -10/*targetPosIndex + aheadStage > StageIndex*/)
        {
            StageManager(targetPosIndex /*(int)StageList[8].gameObject.transform.position.z */+ aheadStage);
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

        while (StageList.Count > aheadStage + 0)//�Â��X�e�[�W���폜����
        {
            Debug.Log("delete");
            DestroyStage();
        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)//�X�e�[�W�𐶐�����
    {
        int nextStage = Random.Range(0, stagenum.Length);

        GameObject stageObject = (GameObject)Instantiate(stagenum[nextStage], new Vector3(0, 0, index * StageSize), Quaternion.identity);

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