using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    //FadeCanvas取得
    [SerializeField]
    private Fade fade;

    //フェード時間（秒）
    [SerializeField]
    private float fadeTime;


    // Start is called before the first frame update
    void Start()
    {
        if (fade == null)
        {
            Debug.Log("FadeCanvasがInspectorにないよ。");
        }

        //シーン開始時にフェードを掛ける
        //fade.FadeOut(fadeTime);
    }

    //各ボタンを押した時の処理
    public void SceneTransition(string sceneName)
    {
        // SEを流す

        //フェードを掛けてからシーン遷移する
        fade.FadeIn(fadeTime, () =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
}
