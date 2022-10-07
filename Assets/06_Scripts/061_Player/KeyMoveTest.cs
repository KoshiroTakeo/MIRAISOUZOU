using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMoveTest : MonoBehaviour
{

    //キャラクターの操作状態を管理するフラグ
    [SerializeField] public bool onGround = true;
    [SerializeField] public bool inJumping = false;

    //rigidbodyオブジェクト格納用変数
    Rigidbody rb;

    //移動速度の定義
    float speed = 16f;

    //ダッシュ速度の定義
    float sprintspeed = 9f;

    //方向転換速度の定義
    float angleSpeed = 200;

    //移動の係数格納用変数
    float v;
    float h;

    void Update() //20220429 StartからUpdateへ訂正
    {
        v = Time.deltaTime * sprintspeed;

        //Shift+上下キーでダッシュ、上下キーで通常移動,それ以外は停止
        //if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
        //    v = Time.deltaTime * sprintspeed;
        //else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
        //    v = -Time.deltaTime * sprintspeed;
        //else if (Input.GetKey(KeyCode.UpArrow))
        //    v = Time.deltaTime * speed;
        //else if (Input.GetKey(KeyCode.DownArrow))
        //    v = -Time.deltaTime * speed;
        //else
        //    v = 0;

        //移動の実行
        if (!inJumping)//空中での移動を禁止
        {
            transform.position += transform.forward * v;
        }

        //スペースボタンでジャンプする
        if (onGround)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //ジャンプさせるため上方向に力を発生
                rb.AddForce(transform.up * 8, ForceMode.Impulse);
                //ジャンプ中は地面との接触判定をfalseにする
                onGround = false;
                inJumping = true;

                //前後キーを押しながらジャンプしたときは前後方向の力も発生
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddForce(transform.forward * 6f, ForceMode.Impulse);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.AddForce(transform.forward * -3f, ForceMode.Impulse);
                }
            }
        }


        //左右キーで方向転換
        if (Input.GetKey(KeyCode.RightArrow))
            h = Time.deltaTime * angleSpeed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            h = -Time.deltaTime * angleSpeed;
        else
            h = 0;

        //方向転換動作の実行
        transform.Rotate(Vector3.up * h);

    }
    //地面に接触したときにはonGroundをtrue、injumpingをfalseにする
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            onGround = true;
            inJumping = false;
        }
    }
}
