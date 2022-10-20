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

        for (int i = StageIndex + 1; i <= maps; i++)//指定したステージまで作成する
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 1)//古いステージを削除する
        {
            Debug.Log("delete");
            DestroyStage();
        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)//ステージを生成する
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
//    //int型を変数StageTipSizeで宣言します。
//    const int StageTipSize = 30;
//    //int型を変数currentTipIndexで宣言します。
//    int currentTipIndex;
//    //ターゲットキャラクターの指定が出来る様にするよ
//    public Transform character;
//    //ステージチップの配列
//    public GameObject[] stageTips;
//    //自動生成する時に使う変数startTipIndex
//    public int startTipIndex;
//    //ステージ生成の先読み個数
//    public int preInstantiate;
//    //作ったステージチップの保持リスト
//    public List<GameObject> generatedStageList = new List<GameObject>();

//    void Start()
//    {
//        //初期化処理
//        currentTipIndex = startTipIndex - 1;
//        UpdateStage(preInstantiate);
//    }


//    void Update()
//    {
//        //キャラクターの位置から現在のステージチップのインデックスを計算します
//        int charaPositionIndex = (int)(character.position.z / StageTipSize);
//        //次のステージチップに入ったらステージの更新処理を行います。
//        if (charaPositionIndex + preInstantiate > currentTipIndex)
//        {
//            UpdateStage(charaPositionIndex + preInstantiate);
//        }

//    }
//    //指定のインデックスまでのステージチップを生成して、管理下におく
//    void UpdateStage(int toTipIndex)
//    {
//        if (toTipIndex <= currentTipIndex) return;
//        //指定のステージチップまで生成するよ
//        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
//        {
//            GameObject stageObject = GenerateStage(i);
//            //生成したステージチップを管理リストに追加して、
//            generatedStageList.Add(stageObject);
//        }
//        //ステージ保持上限になるまで古いステージを削除します。
//        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

//        currentTipIndex = toTipIndex;
//    }
//    //指定のインデックス位置にstageオブジェクトをランダムに生成
//    GameObject GenerateStage(int tipIndex)
//    {
//        int nextStageTip = Random.Range(0, stageTips.Length);

//        GameObject stageObject = (GameObject)Instantiate(
//            stageTips[nextStageTip],
//            new Vector3(0, 0, tipIndex * StageTipSize),
//            Quaternion.identity);
//        return stageObject;
//    }
//    //一番古いステージを削除します
//    void DestroyOldestStage()
//    {
//        GameObject oldStage = generatedStageList[0];
//        generatedStageList.RemoveAt(0);
//        Destroy(oldStage);
//    }

//}