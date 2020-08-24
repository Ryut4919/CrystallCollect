using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// 音量調整
/// </summary>
public class VolumeSetting : MonoBehaviour
{
    public AudioMixer Mixer;

    public void SetVolume(float sliderVolume) 
    {
        Mixer.SetFloat("Sound", Mathf.Log10(sliderVolume) * 20);
    }
}
