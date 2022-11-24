using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletGenerate : MonoBehaviour
{
    //弾プレハブ
    public GameObject HbulletObject;
    //弾発射時のエフェクト
    public GameObject HbulletEffect;
    //プレイヤーのプレハブ
    public GameObject Player;
    //敵のプレハブ
    public GameObject HEnemy;
    //敵の左肩
    public GameObject LeftShoulder_Pos;
    //敵の右肩
    public GameObject RightShoulder_Pos;
    //時間間隔の最小値
    public float minTime = 3.0f;
    //時間間隔の最大値
    public float maxTime = 5.0f;
    //弾生成時間間隔
    private float Hitinterval;
    //経過時間
    private float Hittime = 0.0f;
    //プレイヤーと敵の距離
    private float distance;
    //弾を止める時の距離
    public float BulletStop = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        Hitinterval = GetRandomTime();

        //オブジェクトを見つける
        Player = GameObject.Find("Player_XRRig");
        HEnemy = GameObject.Find("Stage1_Boss");
        LeftShoulder_Pos = GameObject.Find("LeftLauncher");
        RightShoulder_Pos = GameObject.Find("RightLauncher");
    }

    // Update is called once per frame
    void Update()
    {

        //時間計測
        Hittime += Time.deltaTime;

        //プレイヤーの方向を向く
        //transform.LookAt(Player.transform);

        //プレイヤーと敵の位置

        distance = HEnemy.transform.position.z - Player.transform.position.z;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (Hittime > Hitinterval)
        {
            if (distance > BulletStop)
            {
                //弾をインスタンス化する(生成する)
                GameObject Hitbullet = Instantiate(HbulletObject);
                //生成した弾の位置を設定する
                int i;
                i = GetRandom(); 
                if (i == 0)
                {
                    Hitbullet.transform.position = LeftShoulder_Pos.transform.position;
                }
                if (i == 1)
                {
                    Hitbullet.transform.position = RightShoulder_Pos.transform.position;
                }

                //エフェクトを生成する
                GameObject effect = Instantiate(HbulletEffect) as GameObject;
                //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
                effect.transform.position = Hitbullet.transform.position;
                //経過時間を初期化して再度時間計測を始める
                Hittime = 0.0f;
                //次に発生する時間間隔を決定する
                Hitinterval = GetRandomTime();
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
        return Random.Range(0, 2);
    }
}
