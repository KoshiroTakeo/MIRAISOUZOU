using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    //int型を変数StageTipSizeで宣言します。
    const int StageTipSize = 30;
    //int型を変数currentTipIndexで宣言します。
    int currentTipIndex;
    //ターゲットキャラクターの指定が出来る様にするよ
    public Transform character;
    //ステージチップの配列
    public GameObject[] stageTips;
    //自動生成する時に使う変数startTipIndex
    public int startTipIndex;
    //ステージ生成の先読み個数
    public int preInstantiate;
    //作ったステージチップの保持リスト
    public List<GameObject> generatedStageList = new List<GameObject>();

    void Start()
    {
        //初期化処理
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
    }


    void Update()
    {
        //キャラクターの位置から現在のステージチップのインデックスを計算します
        int charaPositionIndex = (int)(character.position.z / StageTipSize);
        //次のステージチップに入ったらステージの更新処理を行います。
        if (charaPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }

    }
    //指定のインデックスまでのステージチップを生成して、管理下におく
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;
        //指定のステージチップまで生成するよ
        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            //生成したステージチップを管理リストに追加して、
            generatedStageList.Add(stageObject);
        }
        //ステージ保持上限になるまで古いステージを削除します。
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

        currentTipIndex = toTipIndex;
    }
    //指定のインデックス位置にstageオブジェクトをランダムに生成
    GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip],
            new Vector3(0, 0, tipIndex * StageTipSize),
            Quaternion.identity);
        return stageObject;
    }
    //一番古いステージを削除します
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }

}