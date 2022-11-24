using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBulletHit : MonoBehaviour
{
    //弾のスピード
    public float BulletSpeed = 1.0f;
    //ゲームスピード
    public float GameSpeed = 1.0f;
    //プレイヤースピード
    public float PlayerSpeed = 1.0f;

    //弾がプレイヤーと当たった時のエフェクト
    public GameObject HitEffect;
    //プレイヤープレハブ
    public GameObject Player;
    //プレイヤープレハブ
    public GameObject TEnemy;
    //弾を消す座標
    public float BulletDeletePos = -50.0f;
    //プレイヤー座標を一時的に格納
    Vector3 Player_pos;
    //エネミーー座標を一時的に格納
    Vector3 TEnemy_pos;
    //自分のー座標を一時的に格納
    Vector3 My_pos;
    //ゲームマネージャー参照用
    private GameManager GameMng;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトを見つける
        Player = GameObject.Find("Player_XRRig");
        TEnemy = GameObject.Find("Stage1_Boss");

        //ゲームマネージャーを参照
        GameMng = GameObject.Find("GameManager").GetComponent<GameManager>();

        Player_pos = Player.transform.position;
        TEnemy_pos = TEnemy.transform.position;
        My_pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //(A,B,速度)AからBまで移動 
        transform.position = Vector3.MoveTowards(transform.position,
            (Player_pos - My_pos) * 10.0f,           //弾を撃った時の(プレイヤーの位置-敵の位置)ベクトルを計算
            BulletSpeed * GameMng.WorldTime * GameMng.AccelSpeed);     // 速度

        //弾のZ軸の位置がBulletDeletePos以下の時
        if (gameObject.transform.position.z < BulletDeletePos)
        {
            //弾を削除
            Destroy(gameObject);
        }
    }

    // 当たり判定
    private void OnCollisionEnter(Collision collision)
    {
        //衝突したオブジェクトがPlayerだったとき
        if (collision.gameObject.CompareTag("Player"))
        {
            //弾を削除
            Destroy(gameObject);

            //エフェクトを発生させる
            //GenerateHitEffect();
        }

        //衝突したオブジェクトがPlayerだったとき
        if (collision.gameObject.CompareTag("Weapon"))
        {
            //弾を削除
            Destroy(gameObject);

            //エフェクトを発生させる
            //GenerateHitEffect();
        }

    }
    void GenerateHitEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(HitEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }
}
