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
            Debug.Log("SEが設定されていないよ。");
        }
    }

    void Update()
    {
    }

    IEnumerator DelayMethod()
    {
        //delay秒待つ
        yield return new WaitForSeconds(timer);
    }

    public void sceneChange(string sceneName)//ボタン操作などで呼び出す
    {
        if (!firstPush)
        {
            // SEを流す
            se.GetComponent<SEManager>().PlaySE(1);
            StartCoroutine(DelayMethod());

            /*処理*/
            // サブシーンに切り替える
            SceneManager.LoadScene(sceneName);

            firstPush = true;
        }
    }
}
