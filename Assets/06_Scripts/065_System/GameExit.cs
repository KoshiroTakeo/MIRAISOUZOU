using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class GameExit : MonoBehaviour
{
    GameObject se;

    // Start is called before the first frame update
    void Start()
    {
        se = GameObject.Find("SE");

        if (se == null)
        {
            Debug.Log("SE���ݒ肳��Ă��Ȃ���B");
        }
    }

    //�Q�[���I��:�{�^������Ăяo��
    public void EndGame()
    {
        se.GetComponent<SEManager>().PlaySE(1);

        //#if UNITY_EDITOR
        // �G�f�B�^�[����I�����������Ƃ�
        //UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
        //#else
        Application.Quit();//�Q�[���v���C�I��
                           //#endif
    }

}