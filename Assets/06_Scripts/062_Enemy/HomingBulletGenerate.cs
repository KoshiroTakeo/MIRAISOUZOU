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
    public GameObject Enemy;
    //時間間隔の最小値
    public float minTime = 3.0f;
    //時間間隔の最大値
    public float maxTime = 5.0f;
    //弾生成時間間隔
    private float Hitinterval;
    //経過時間
    private float Hittime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        Hitinterval = GetRandomTime();

        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("HomingEnemy");
    }

    // Update is called once per frame
    void Update()
    {

        //時間計測
        Hittime += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (Hittime > Hitinterval)
        {
            //弾をインスタンス化する(生成する)
            GameObject Hitbullet = Instantiate(HbulletObject);
            //生成した弾の位置をランダム(X=-20～20,Y=0,Z=50)に設定する
            Hitbullet.transform.position = Enemy.transform.position;
            //プレイヤーの方向を向く
            transform.LookAt(Player.transform);

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

    // 指定した範囲でランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

}
