using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMove : MonoBehaviour
{
    //フィールド移動速度
    public float Field_Speed = 0;

    //フィールド再設置位置オブジェクト
    public GameObject Pop_Point;

    //GemeManagerの変数持ってくる用
    private GameManager GameMng;

    private void Start()
    {
        Pop_Point = GameObject.Find("FieldPopPoint");

        GameMng = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {
        //フィールドの移動実行
        transform.position -= new Vector3(0, 0, Time.deltaTime * Field_Speed * GameMng.WorldTime * GameMng.AccelSpeed);

        if (transform.position.z <= -5.0f)
        {
            transform.position = Pop_Point.transform.position;
        }
    }

    //プレイヤーダメージ時減速
    public void PlayerDamage()
    {
        Field_Speed = Field_Speed - 1.0f;
    }
}