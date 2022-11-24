using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulletGenerate : MonoBehaviour
{
    //弾プレハブ
    public GameObject TbulletObject;
    //弾発射時のエフェクト
    public GameObject TbulletEffect;
    //プレイヤーのプレハブ
    public GameObject Player;
    //敵のプレハブ
    public GameObject TEnemy;
    //敵の左手
    public GameObject LeftHand_Pos;
    //敵の右手
    public GameObject RightHand_Pos;
    //敵の左足
    public GameObject LeftLeg_Pos;
    //敵の右足
    public GameObject RightLeg_Pos;
    //敵の中央
    public GameObject Center_Pos;
    //時間間隔の最小値
    public float minTime = 3.0f;
    //時間間隔の最大値
    public float maxTime = 5.0f;
    //弾生成時間間隔
    private float Hinterval;
    //経過時間
    private float Htime = 0.0f;
    //プレイヤーと敵の距離
    private float distance;
    //弾を止める時の距離
    public float BulletStop = 20.0f;



    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        Hinterval = GetRandomTime();

        //オブジェクトを見つける
        Player = GameObject.Find("Player_XRRig");
        TEnemy = GameObject.Find("Stage1_Boss");
        LeftHand_Pos = GameObject.Find("LeftHandLauncher");
        RightHand_Pos = GameObject.Find("RightHandLauncher");
        LeftLeg_Pos = GameObject.Find("LeftLegLauncher");
        RightLeg_Pos = GameObject.Find("RightLegLauncher");
        Center_Pos = GameObject.Find("CenterLauncher");
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        Htime += Time.deltaTime;

        //プレイヤーの方向を向く
        //transform.LookAt(Player.transform);
         
        //プレイヤーと敵の位置
        distance = TEnemy.transform.position.z - Player.transform.position.z;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (Htime > Hinterval)
        {
            if (distance > BulletStop)
            {
                //弾をインスタンス化する(生成する)
                GameObject Hbullet = Instantiate(TbulletObject);
                //生成した弾の位置を設定する
                int i;
                i = GetRandom();
                switch(i)
                {
                    case 0:
                        Hbullet.transform.position = Center_Pos.transform.position;
                        break;
                    case 1:
                        Hbullet.transform.position = LeftHand_Pos.transform.position;
                        break;
                    case 2:
                        Hbullet.transform.position = RightHand_Pos.transform.position;
                        break;
                    case 3:
                        Hbullet.transform.position = LeftLeg_Pos.transform.position;
                        break;
                    case 4:
                        Hbullet.transform.position = RightLeg_Pos.transform.position;
                        break;
                    default:
                        Hbullet.transform.position = Center_Pos.transform.position;
                        break;

                }

                //エフェクトを生成する
                GameObject effect = Instantiate(TbulletEffect) as GameObject;
                //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
                effect.transform.position = Hbullet.transform.position;

                //経過時間を初期化して再度時間計測を始める
                Htime = 0.0f;
                //次に発生する時間間隔を決定する
                Hinterval = GetRandomTime();
            }

        }
    }
    // 指定した範囲でランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    private int GetRandom()
    {
        return Random.Range(0, 5);
    }
}
