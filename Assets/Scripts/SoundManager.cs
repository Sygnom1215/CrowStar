using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{

    [SerializeField] private AudioClip[] effectSounds = null;
    [SerializeField] private AudioClip[] bgms = null;

    private AudioSource bgmAudio;
    private AudioSource soundEffectAudio;

    private void Awake()
    {
        SoundManager[] smanagers = FindObjectsOfType<SoundManager>();
        if (smanagers.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);

        bgmAudio = GetComponent<AudioSource>();
        soundEffectAudio = transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void BGMVolume(float value)
    {
        if (bgmAudio == null) return;
        bgmAudio.volume = value;

        DataManager.Instance.CurrentPlayer.bgmSoundVolume = value;
    }

    public void EffectVolume(float value)
    {
        if (soundEffectAudio == null) return;
        soundEffectAudio.volume = value;

        DataManager.Instance.CurrentPlayer.effectSoundVolume = value;
    }
    public void SetBGM(int bgmNum)
    {
        Debug.Log("À½¾Ç");
        Debug.Log(bgms.Length);

        bgmAudio.Stop();
        bgmAudio.clip = bgms[bgmNum];
        bgmAudio.Play();
    }
    public void SetEffectSound(int effectNum)
    {
        Debug.Log(effectSounds.Length);

        soundEffectAudio.Stop();
        soundEffectAudio.clip = effectSounds[effectNum];
        soundEffectAudio.Play();
    }
    public void StopBGM()
    {
        bgmAudio.Stop();
    }
}