using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMusic
{
    AudioClip[] GetAudioClips();
    void PlaySound(int No);
    void StopSound();
}

public class MusicPlayer : MonoBehaviour,IMusic
{
    public static MusicPlayer instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public AudioClip[] soundList = new AudioClip[10];

    AudioClip[] IMusic.GetAudioClips()
    {
        return soundList;
    }

    void IMusic.PlaySound(int No)
    {

    }

    void IMusic.StopSound()
    {

    }
}