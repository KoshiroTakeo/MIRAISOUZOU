using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IDamage
{
    void DamageEffect(int damage);
}

public class DamageUI : MonoBehaviour,IDamage
{
    public static DamageUI instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    bool damage_flg = false;

    // 画面を赤にするためのイメージ
    public Image img;

    void Start()
    {
        // 透明にして見えなくしておきます。
        img.color = Color.clear;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        int count = 0;

        for (count = 0; count < 5; count++)
        {
            DamageEffect(count);
            // 時間が経過するにつれて徐々に透明にします。
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime * 0.1f);
        }
    }

    public virtual void DamageEffect(int damage)
    {
        //既にダメージ状態（＝無敵時間中）なら終了
        if (damage_flg)
        {
            return;
        }

        damage_flg = true;

        // *画面を赤塗りにする
        this.img.color = new Color(1f, 0f, 0f, 1f);
    }
}
