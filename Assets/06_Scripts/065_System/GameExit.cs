using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour,IMusic
{
    AudioSource audioSource;

    public GameObject buttonObj;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    //ゲーム終了:ボタンから呼び出す
    public void EndGame()
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

        //#if UNITY_EDITOR
        // エディターから終了させたいとき
        //UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        //#else
        Application.Quit();//ゲームプレイ終了
                           //#endif
    }

}