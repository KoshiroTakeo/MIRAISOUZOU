using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPManager : MonoBehaviour
{
    public GameObject Boss;

    //　最大HP
    [SerializeField]
    private int maxHP = 10000;
    //　徐々に減らしていくhp計測に使う
    [SerializeField]
    private int hp;
    //　最終的なhp計測に使う
    private int finalHP;
    //　HPを一度減らしてからの経過時間
    private float countTime = 0f;
    //　次にHPを減らすまでの時間
    [SerializeField]
    private float nextCountTime = 0f;
    //　HP表示用スライダー
    private Slider hpSlider;
    //　一括HP表示用スライダー
    private Slider bulkHPSlider;
    //　現在のダメージ量
    private int damage = 0;
    //　一回に減らすダメージ量
    [SerializeField]
    private int amountOfDamageAtOneTime = 100;
    //　HPを減らしているかどうか
    private bool isReducing;
    //　HP用表示スライダーを減らすまでの待機時間
    [SerializeField]
    private float delayTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = transform.Find("HUD/Canvas/HPSlider").GetComponent<Slider>();
        bulkHPSlider = transform.Find("HUD/Canvas/BlukSlider").GetComponent<Slider>();
        hp = maxHP = GameObject.FindWithTag("Boss").GetComponent<EnemyCommon>().Life;
        finalHP = maxHP;
        hpSlider.value = 1;
        bulkHPSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //　ダメージなければ何もしない
        if (!isReducing)
        {
            return;
        }

        //　次に減らす時間がきたら
        if (countTime >= nextCountTime)
        {
            int tempDamage;
            //　決められた量よりも残りダメージ量が小さければ小さい方を1回のダメージに設定
            tempDamage = Mathf.Min(amountOfDamageAtOneTime, damage);
            hp -= tempDamage;
            //　全体の比率を求める
            hpSlider.value = (float)hp / maxHP;
            //　全ダメージ量から1回で減らしたダメージ量を減らす
            damage -= tempDamage;
            //　全ダメージ量が0より下になったら0を設定
            damage = Mathf.Max(damage, 0);

            countTime = 0f;
            //　ダメージがなくなったらHPバーの変更処理をしないようにする
            if (damage <= 0)
            {
                isReducing = false;
            }

            //　HPが0以下になったら敵を削除
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        countTime += Time.deltaTime;
    }

    //　ダメージ値を追加するメソッド
    public void TakeDamage(int damage)
    {
        //　ダメージを受けた時に一括HP用のバーの値を変更する
        var tempHP = Mathf.Max(finalHP -= damage, 0);
        bulkHPSlider.value = (float)tempHP / maxHP;
        this.damage += damage;
        countTime = 0f;
        //　一定時間後にHPバーを減らすフラグを設定
        Invoke("StartReduceHP", delayTime);
    }

    //　徐々にHPバーを減らすのをスタート
    public void StartReduceHP()
    {
        isReducing = true;
    }
}

