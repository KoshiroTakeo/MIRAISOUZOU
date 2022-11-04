using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    GameObject se;
    public float timer = 3.0f;
    private bool firstPush = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        firstPush = false;

        se = GameObject.Find("SE");

        if (se == null)
        {
            Debug.Log("SE���ݒ肳��Ă��Ȃ���B");
        }
    }

    void Update()
    {
    }

    IEnumerator DelayMethod()
    {
        //delay�b�҂�
        yield return new WaitForSeconds(timer);
    }

    public void sceneChange(string sceneName)//�{�^������ȂǂŌĂяo��
    {
        if (!firstPush)
        {
            // SE�𗬂�
            se.GetComponent<SEManager>().PlaySE(1);
            StartCoroutine(DelayMethod());

            /*����*/
            // �T�u�V�[���ɐ؂�ւ���
            SceneManager.LoadScene(sceneName);

            firstPush = true;
        }
    }
}
