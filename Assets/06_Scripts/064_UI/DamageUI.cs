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

    // ��ʂ�Ԃɂ��邽�߂̃C���[�W
    public Image img;

    void Start()
    {
        // �����ɂ��Č����Ȃ����Ă����܂��B
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
            // ���Ԃ��o�߂���ɂ�ď��X�ɓ����ɂ��܂��B
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime * 0.1f);
        }
    }

    public virtual void DamageEffect(int damage)
    {
        //���Ƀ_���[�W��ԁi�����G���Ԓ��j�Ȃ�I��
        if (damage_flg)
        {
            return;
        }

        damage_flg = true;

        // *��ʂ�ԓh��ɂ���
        this.img.color = new Color(1f, 0f, 0f, 1f);
    }
}
