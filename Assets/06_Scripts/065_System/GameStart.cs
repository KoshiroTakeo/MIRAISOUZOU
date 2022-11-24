using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour,IMusic
{

    AudioSource audioSource;

    public GameObject buttonObj;
    
    private bool firstPush = false;

    //FadeCanvas取得
    [SerializeField]
    private Fade fade;

    //フェード時間取得（秒）
    [SerializeField]
    private float fadeTime;



    // Start is called before the first frame update
    void Start()
    {
        firstPush = false;

        audioSource = buttonObj.GetComponent<AudioSource>();
    }

    //------------------------------------------------------------------
    //
    AudioClip[] IMusic.GetAudioClips()
    {
        return MusicPlayer.instance.soundList;
    }

    void IMusic.PlaySound(int No)
    {
        audioSource.PlayOneShot(MusicPlayer.instance.soundList[No]);
    }

    void IMusic.StopSound()
    {
        audioSource.Stop();
    }
    //------------------------------------------------------------------

    public void PushFadeout()
    {
        fade.FadeOut(fadeTime);
    }

    public void PushFadein()
    {
        fade.FadeIn(fadeTime, () =>
        {
            fade.FadeOut(fadeTime);
        });
    }

    public void sceneChange(string sceneName)//ボタン操作などで呼び出す
    {
        if (!firstPush)
        {
            // SEを流す
            /*
            IMusic iMusic = buttonObj.GetComponent<IMusic>();
            if (iMusic != null)
            {
                iMusic.PlaySound(0);
            }
            */
            SoundManager.Instance.PlaySE(SESoundData.SE.StartButton);

            /*処理*/
            // サブシーンに切り替える
            //フェードを掛けてからシーン遷移する
            fade.FadeIn(fadeTime, () =>
            {
                SceneManager.LoadScene(sceneName);
            });

            firstPush = true;
        }
    }

}
