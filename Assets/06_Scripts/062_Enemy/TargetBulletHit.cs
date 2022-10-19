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
    //弾プレハブ
    public GameObject Bullet;
    //弾を消す座標
    public float BulletDeletePos = -50.0f;
    //プレイヤー座標を一時的に格納
    Vector3 Player_pos;

    //private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        Player_pos = Player.transform.position;

        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, 
            (Player_pos - transform.position), 
            BulletSpeed * GameSpeed * PlayerSpeed);
        
        if(Player_pos == transform.position)
        {
            //Vector3.MoveTowards(-(Player_pos - transform.position), transform.position, BulletSpeed * GameSpeed * PlayerSpeed);
            Destroy(gameObject);
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
        /*
                //衝突したオブジェクトがPlayerだったとき
                if (collision.gameObject.CompareTag("Weapon"))
                {
                    //弾を削除
                    Destroy(gameObject);

                    //エフェクトを発生させる
                    //GenerateHitEffect();
                }
        */
    }
    void GenerateHitEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(HitEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }
}
