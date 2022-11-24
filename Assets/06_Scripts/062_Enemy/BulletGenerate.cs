using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
    //弾プレハブ
    public GameObject BulletObject;
    //弾発射時のエフェクト
    public GameObject BulletEffect;
    //プレイヤーのプレハブ
    public GameObject Player;
    //敵のプレハブ
    public GameObject Enemy;
    //時間間隔の最小値
    public float minTime = 3.0f;
    //時間間隔の最大値
    public float maxTime = 5.0f;
    //弾X座標の最小値
    public float MinBulletPositionX = -20f;
    //弾X座標の最大値
    public float MaxBulletPositionX = 20f;
    //弾のスピード
    //private float BulletSpeed = 100f;
    //弾生成時間間隔
    private float interval;
    //経過時間
    private float time = 0.0f;
    //プレイヤーと敵の距離
    private float distance;
    //弾を止める時の距離
    public float BulletStop = 400.0f;


    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomTime();

        //オブジェクトを見つける
        //Player = GameObject.Find("Player_XRRig");
        //Enemy = GameObject.Find("Stage1_Boss");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //時間計測
        time += Time.deltaTime;

        //プレイヤーと敵の位置
        distance = Enemy.transform.position.z; //- Player.transform.position.z;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            //一定距離の時弾を生成しない
            if (distance > BulletStop)
            {
                //弾をインスタンス化する(生成する)
                GameObject bullet = Instantiate(BulletObject);
                //生成した弾の位置をランダム(X=-20～20,Y=0,Z=50)に設定する
                bullet.transform.position = GetRandomPosition();

                //エフェクトを生成する
                GameObject effect = Instantiate(BulletEffect) as GameObject;
                //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
                effect.transform.position = bullet.transform.position;

                //経過時間を初期化して再度時間計測を始める
                time = 0.0f;
                //次に発生する時間間隔を決定する
                interval = GetRandomTime();
            }
        }
    }

    // 指定した範囲でランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //指定した範囲でランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //X座標をランダムに生成する
        float x = Random.Range(MinBulletPositionX, MaxBulletPositionX);
        float y = 1.0f; // 10/20竹尾変更中（元：0.0f）
        //float z = 400.0f; // 10/20竹尾変更中（元：50.0f）
        float z = Enemy.transform.position.z - 20.0f; 

        //Vector3型のPositionを返す
        return new Vector3(x, y, z);
    }
}
