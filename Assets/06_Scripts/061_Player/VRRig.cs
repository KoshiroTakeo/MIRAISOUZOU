//============================================================
// VRRig.cs
//======================================================================
// 開発履歴
//
// 2022/05/28 author 竹尾：制作、HMDに合わせたモデルの動作
// 参考：https://www.youtube.com/watch?v=tBYl-aSxUe0
// 
//
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // サブプロパティ表示（Serializebleはそういう表示させるもの）
public class VRMap
{
    public Transform vrTarget;              // VR上で実際に動かす頭、腕等のオブジェクト
    public Transform rigTarget;             // TwoBoneIKConstrains等でRigを通したターゲット
    public Vector3 trackingPosittionOffset; 
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPosittionOffset);             // ローカル空間からワールド空間へ position を変換
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset); // オイラー角（3つの角度組による）による回転制御
    }
}

public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap lefthand;
    public VRMap righthand;

    [SerializeField] public Transform headconstrain;
    [SerializeField] public Vector3 headBodyOffset;
   
    void Start()
    {
        headBodyOffset = transform.position - headconstrain.position; // 初期補正
    }

    void LateUpdate() // Updateにしても問題ない（VRMapの処理順によっては不可能）
    {
        transform.position = headconstrain.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headconstrain.up, Vector3.up).normalized; // 斜面に対応させる

        head.Map();
        lefthand.Map();
        righthand.Map();
    }
}
