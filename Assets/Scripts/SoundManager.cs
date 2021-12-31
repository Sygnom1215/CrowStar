using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource bgmAudio;
    private AudioSource soundEffectAudio;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        bgmAudio = GetComponent<AudioSource>();
        soundEffectAudio = transform.GetChild(0).GetComponent<AudioSource>();
    }
}