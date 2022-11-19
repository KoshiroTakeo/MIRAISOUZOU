using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    //弾のスピード
    private float BulletSpeed = 0.7f; // 10/20竹尾変更中（元：0.1f）
    //ゲームスピード
    public float GameSpeed = 1.0f;
    //プレイヤースピード
    public float PlayerSpeed = 1.0f;

    //弾がプレイヤーと当たった時のエフェクト
    public GameObject HitEffect;
    //弾を消す座標
    public float BulletDeletePos = -50.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3という型に値を入れ、計算
        Vector3 BulletPos = transform.position;
        //弾の速度を加算（弾速度×ゲームスピード×プレイヤースピード）
        BulletPos.z += -BulletSpeed * GameSpeed * PlayerSpeed;
        //ポジションに代入
        transform.position = BulletPos;

        //弾のZ軸の位置がBulletDeletePos以下の時
        if (gameObject.transform.position.z < BulletDeletePos)
        {
            //弾を削除
            Destroy(gameObject);
        }
    }

    // 当たり判定
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
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

            Debug.Log("斬れた");

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
