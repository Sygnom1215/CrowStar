using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private ESoundSliderType type;

    private void Start()
    {
        float value = 0.5f;
        if(type ==  ESoundSliderType.BGMSound)
        {
            value = DataManager.Instance.CurrentPlayer.bgmSoundVolume;
        }

        else
        {
            value = DataManager.Instance.CurrentPlayer.effectSoundVolume;
        }

        soundSlider.value = value;
    }

    public void SetEffectSoundVolume(float value)
    {
        SoundManager.Instance.EffectVolume(value);
        DataManager.Instance.CurrentPlayer.effectSoundVolume = value;
    }

    public void SetBGMSoundVolume(float value)
    {
        SoundManager.Instance.BGMVolume(value);
        DataManager.Instance.CurrentPlayer.bgmSoundVolume = value;
    }
}
