using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボダンを選ぶ時の音を表示する
/// </summary>
public class SelectSound : Selectable
{

    private SoundManager _soundmanager;
    //選択しているかどうかの確認用
    private bool onhighligth = false;


    private void Awake()
    {
        _soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void Update()
    {
        
        if (IsHighlighted() && !onhighligth)
        {
            OnSelect();
        }
        else if (!IsHighlighted())
        {
            onhighligth = false;
        }
    }

    private void OnSelect()
    {
        _soundmanager.SelectSE();
        onhighligth = true;
    }

}
