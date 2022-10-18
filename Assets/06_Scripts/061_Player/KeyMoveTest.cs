//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KeyMoveTest : MonoBehaviour
//{

//    //キャラクターの操作状態を管理するフラグ
//    [SerializeField] public bool onGround = true;
//    [SerializeField] public bool inJumping = false;

//    public bool PlayerDamage = false;//プレイヤーダメージ判定

//    //rigidbodyオブジェクト格納用変数
//    Rigidbody rb;

//    //移動速度の定義
//    public float Speed = 0f;

//    //ダメージ時移動速度の定義
//    public float Damage_Speed = 0f;

//    //移動の係数格納用変数
//    float v;

//    void Update() //20220429 StartからUpdateへ訂正
//    {
//        if (PlayerDamage == false)
//        {
//            v = Time.deltaTime * Speed;

//            //移動の実行
//            if (!inJumping)//空中での移動を禁止
//            {
//                transform.position += transform.forward * v;
//            }

//        }
//        else if (PlayerDamage == true)
//        {
//            v = /*Time.deltaTime **/ Damage_Speed;
//            transform.position += transform.forward * v;
//        }
//    }

//    public void PlayerDamage()
//    {

//    }
//}
