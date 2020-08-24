using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource SoundEffect;

    [SerializeField]
    private AudioClip SelectSound, ComfirmSound,GetPointSound,GameClearSound,ShutterDownSound;

    private void Awake()
    {
        if (instance = null) 
        {
            instance = this;
        }
    }

    //選ぶ時の音
    public void SelectSE() 
    {
        SoundEffect.clip = SelectSound;
        SoundEffect.Play();
    }

    //確認した時の音
    public void ComfirmSE() 
    {
        SoundEffect.clip = ComfirmSound;
        SoundEffect.Play();
    }

    //クリスタルを取った時の音
    public void GetPointSE() 
    {
        SoundEffect.clip = GetPointSound;
        SoundEffect.Play();
    }

    //ゲームクリア時の音
    public void GameClearSE() 
    {
        SoundEffect.clip = GameClearSound;
        SoundEffect.Play();
    }

    //ブロックを解除した時の音
    public void ShutterDownSE()
    {
        SoundEffect.clip = ShutterDownSound;
        SoundEffect.Play();
    }
}
