using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画面内のUIとゲーム停止の処理
/// </summary>
public class GUIScript : MonoBehaviour
{
    public bool Pause = false;

    [SerializeField]
    private GameObject MenuPanel;

    [SerializeField]
    private SoundManager _soundManager;

    /// <summary>
    /// 他の機能でゲーム停止も使いますので、これをメニュー表示をコントロール
    /// </summary>
    public bool MenuPause = false;

    [SerializeField]
    private GameObject _tipsToggle,_settingPanel,_tipsPanel, _miniMapToggle;

    [SerializeField]
    private Camera _miniMapCamera;

    GameManager _gameManager;



    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }
    private void Update()
    {
        //メニューボタンの処理
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause = !Pause;
            MenuPause = !MenuPause;
            _soundManager.SelectSE();
        }

        CheckPause();
    }

    private void CheckPause() 
    {
        if (Pause&&MenuPause) 
        {
            MenuPanel.SetActive(true);
        }
        else 
        {
            MenuPanel.SetActive(false);
            _settingPanel.SetActive(false);
        }
    }

    private void OnGUI()
    {

        if (!Pause && !_gameManager.GameOver && !_gameManager.GameClear)
        {
            //左上にボダン表示
            if (GUI.Button(new Rect(25, 15, 100, 30), "Esc"))
            { }
            //マウスを隠れ
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {
            Cursor.visible = true;
        }
    }

    public void BackToGame() 
    {
        Pause = false;
        MenuPause = false;
    }

    public void OpenSettingPanel() 
    {
        _settingPanel.SetActive(true);
        Cursor.visible = true;
    }

    public void CloseSettingPanel() 
    {
        _settingPanel.SetActive(false);
    }

    //操作ヒントの表示と非表示管理
    public void TipsOnOff() 
    {
        if (_tipsToggle.GetComponent<Toggle>().isOn)
        {
            _tipsPanel.SetActive(true);
        }
        else 
        {
            _tipsPanel.SetActive(false) ;
        }
    }

    //ミニマップのクリスタルを表示と非表示
    public void CrystalOnOff() 
    {
        _miniMapCamera.cullingMask ^= 1 << LayerMask.NameToLayer("Crystal");
    }
}
