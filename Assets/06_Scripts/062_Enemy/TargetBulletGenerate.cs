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
    //時間間隔の最小値
    public float minTime = 3.0f;
    //時間間隔の最大値
    public float maxTime = 5.0f;
    //弾生成時間間隔
    private float Hinterval;
    //経過時間
    private float Htime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        Hinterval = GetRandomTime();

        Player = GameObject.Find("Player");
        TEnemy = GameObject.Find("TargetEnemy");
    }

    // Update is called once per frame
    void Update()
    {

        //時間計測
        Htime += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (Htime > Hinterval)
        {
            //弾をインスタンス化する(生成する)
            GameObject Hbullet = Instantiate(TbulletObject);
            //生成した弾の位置をランダム(X=-20～20,Y=0,Z=50)に設定する
            Hbullet.transform.position = TEnemy.transform.position;

            transform.LookAt(Player.transform);

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

    // 指定した範囲でランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }
}
