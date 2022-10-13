using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
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
        if (gameObject.transform.position.z < BulletDeletePos)
        {
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
            GenerateHitEffect();
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
