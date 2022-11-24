using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //弾のスピード
    private float BulletSpeed = 2.1f; // 10/20竹尾変更中（元：0.1f）
    //ゲームスピード
    public float GameSpeed = 1.0f;
    //プレイヤースピード
    public float PlayerSpeed = 1.0f;
    //弾のスピードを変更する位置
    public float BulletLatePos = 100.0f;
    //弾のスピード変更用
    public float BulletLateSpeed;


    //弾がプレイヤーと当たった時のエフェクト
    public GameObject HitEffect;
    //弾を消す座標
    public float BulletDeletePos = -50.0f;
    //ゲームマネージャー参照用
    private GameManager GameMng;


    // Start is called before the first frame update
    void Start()
    {
        //ゲームマネージャーを参照
        GameMng = GameObject.Find("GameManager").GetComponent<GameManager>();
        BulletLateSpeed = 1.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3という型に値を入れ、計算
        Vector3 BulletPos = transform.position;
        //弾の速度を加算（弾速度×ゲームスピード×プレイヤースピード）
        BulletPos.z += -BulletSpeed * GameMng.WorldTime * GameMng.AccelSpeed * BulletLateSpeed * GameSpeed * PlayerSpeed;
        //ポジションに代入
        transform.position = BulletPos;
        if (gameObject.transform.position.z < BulletLatePos)
        {
            BulletLateSpeed = 0.1f;
        }
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
