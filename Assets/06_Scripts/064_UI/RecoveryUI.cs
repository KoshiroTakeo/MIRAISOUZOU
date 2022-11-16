using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IRecovery
{
    void RecoveryEffect(int recovery);
}

public class RecoveryUI : MonoBehaviour,IRecovery
{
    public static RecoveryUI instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool recovery_flg;

    // 画面を赤にするためのイメージ
    public Image img;

    public void Start()
    {
        // 透明にして見えなくしておきます。
        img.color = Color.clear;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        int count = 0;

        for (count = 0; count < 5; count++)
        {
            RecoveryEffect(count);
            // 時間が経過するにつれて徐々に透明にします。
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime * 0.1f);
        }
    }

    public virtual void RecoveryEffect(int recovery)
    {
        //既にダメージ状態（＝無敵時間中）なら終了
        if (recovery_flg)
        {
            return;
        }

        recovery_flg = true;

        // *画面を赤塗りにする
        this.img.color = new Color(0f, 0f, 1f, 1f);
    }
}
