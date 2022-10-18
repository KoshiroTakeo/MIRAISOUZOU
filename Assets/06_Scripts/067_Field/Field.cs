using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    int StageSize = 20;
    int StageIndex;

    public Transform Target;//プレイヤーキャラクター
    public GameObject[] stagenum;//ステージのプレハブ
    public int FirstStageIndex;//スタート時にどのインデックスからステージを生成するのか
    public int aheadStage; //事前に生成しておくステージ
    public List<GameObject> StageList = new List<GameObject>();//生成したステージのリスト

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

        for (int i = StageIndex + 1; i <= maps; i++)//指定したステージまで作成する
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 0)//古いステージを削除する
        {
            Debug.Log("delete");
            DestroyStage();
        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)//ステージを生成する
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