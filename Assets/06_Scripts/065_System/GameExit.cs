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
            Debug.Log("SEが設定されていないよ。");
        }
    }

    //ゲーム終了:ボタンから呼び出す
    public void EndGame()
    {
        se.GetComponent<SEManager>().PlaySE(1);

        //#if UNITY_EDITOR
        // エディターから終了させたいとき
        //UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        //#else
        Application.Quit();//ゲームプレイ終了
                           //#endif
    }

}