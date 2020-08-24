using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{
    //最初のスタートボダン
    [SerializeField]
    private GameObject _anybutton;
    private bool anybool = false;
    public bool anylight = false;

    private bool ButtonIn = false;

    //タイトルシーンにあるのボダンを中に入れて管理用
    [SerializeField]
    GameObject[] buttonList;

    [SerializeField]
    private GameObject settingPanel;

    [SerializeField]
    private GameObject controllPanel;

    [SerializeField]
    private SoundManager _soundManager;

    public bool buttonShow = false;


    // Update is called once per frame
    void Update()
    {
       
        AnyKey();
        if (ButtonIn) 
        {
            for (int i = 0; i < buttonList.Length; i++) 
            {
                buttonList[i].GetComponent<StartButtonMoveIn>().Return = true;
                ButtonIn = false;
            }
        }
    }

    private void AnyKey()
    {
        if (!anybool)
        {
            #region Enykey ボダンが呼吸のように
            Color d = _anybutton.GetComponent<Text>().color;

            if (d.a >= 1f && anylight)
            {
                anylight = false;
            }

            if (!anylight)
            {
                d.a -= 0.005f;
                if (d.a <= 0)
                {
                    anylight = true;
                    d.a = 0;
                }

            }
            if (anylight)
            {
                d.a += 0.005f;
                if (d.a >= 1)
                {
                    anylight = false;
                    d.a = 1;
                }
            }

            _anybutton.GetComponent<Text>().color = d;
            #endregion

            if (Input.anyKeyDown)
            {
                _anybutton.SetActive(false);
                _soundManager.ComfirmSE();
                anybool = true;
                ButtonIn = true;
            }
        }
    }

    /// <summary>
    /// ゲーム設定パネルを表示、メニューボダンを隠れる
    /// </summary>
    public void ShowSetting() 
    {
        
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<StartButtonMoveIn>().Return = false;
        }
        settingPanel.GetComponent<StartButtonMoveIn>().Return = true;
    }

    public void CloseSetting() 
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<StartButtonMoveIn>().Return = true;
        }
        settingPanel.GetComponent<StartButtonMoveIn>().Return = false;
    }

    public void FullScreen(bool isFullScreen) 
    {
        Screen.fullScreen = isFullScreen;
    }

    /// <summary>
    /// 操作説明パネルを表示
    /// </summary>
    public void ControllPanelIn() 
    {
        controllPanel.GetComponent<StartButtonMoveIn>().Return = true;
    }

    public void ControllPanelOut() 
    {
        controllPanel.GetComponent<StartButtonMoveIn>().Return = false;
    }
}
