using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletHit : MonoBehaviour
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
    //エネミープレハブ
    public GameObject Enemy;
    //弾を消す座標
    public float BulletDeletePos = -50.0f;

    private GameManager GameMng;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトを見つける
        Player = GameObject.Find("Player_XRRig");
        Enemy = GameObject.Find("Stage1_Boss");

        //ゲームマネージャーを参照
        GameMng = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, BulletSpeed * GameMng.WorldTime * GameMng.AccelSpeed);

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
