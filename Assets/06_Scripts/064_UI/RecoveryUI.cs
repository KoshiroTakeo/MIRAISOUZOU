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

    // ��ʂ�Ԃɂ��邽�߂̃C���[�W
    public Image img;

    public void Start()
    {
        // �����ɂ��Č����Ȃ����Ă����܂��B
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
            // ���Ԃ��o�߂���ɂ�ď��X�ɓ����ɂ��܂��B
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime * 0.1f);
        }
    }

    public virtual void RecoveryEffect(int recovery)
    {
        //���Ƀ_���[�W��ԁi�����G���Ԓ��j�Ȃ�I��
        if (recovery_flg)
        {
            return;
        }

        recovery_flg = true;

        // *��ʂ�ԓh��ɂ���
        this.img.color = new Color(0f, 0f, 1f, 1f);
    }
}
