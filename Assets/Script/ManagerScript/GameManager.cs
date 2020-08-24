using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
/// <summary>
/// ゲームの情報処理
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool GameOver, GameClear = false;

    /// <summary>
    /// pointText:点数表示
    /// pointNum:ゲーム内のポイント数
    /// point:プレイヤー取ったポイント数
    /// </summary>
    [SerializeField]
    private GameObject _pointText;
    [SerializeField]
    private int _pointNum;
    private int point = 0;

    //ブロックのオブジェクト
    [SerializeField]
    private GameObject _blockList;
    [SerializeField]
    private GameObject _cutScenePanel;
    [SerializeField]
    private GameObject ClearMessege;

    /// <summary>
    /// blockCamera:ブロック前のカメラ、ポイント溜まった場合使う
    /// </summary>
    [SerializeField]
    private GameObject _blockCamera;
    [SerializeField]
    private SoundManager _soundManager;

    private bool block = false;
    private GUIScript _gui;


    private void Awake()
    {
        if (instance = null) 
        {
            instance = this;
        }
        GameOver = false;
        GameClear = false;
        //点数表示用のテクストを探す
        _pointNum = GameObject.FindGameObjectsWithTag("GoalPoint").Length;
        _pointText.GetComponent<Text>().text = " X " + point + " / " + _pointNum;
        _gui = GetComponent<GUIScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (block) 
        {
           
            //ブロックを下へ移動
            _blockList.transform.Translate(0, -0.35f*Time.deltaTime, 0);
        }

        if (GameClear) 
        {
            ClearMessege.SetActive(true);
            //マウスを表示します
            Cursor.visible = true;
        }
    }


    public void GetPoint() 
    {
        //点数+1
        point++;
        //点数表示更新
        _pointText.GetComponent<Text>().text = " X " + point +" / "+ _pointNum;
        //点数全部取った場合
        if (point == _pointNum) 
        {
            StartCoroutine(CutScene());
        }
    }

    IEnumerator CutScene() 
    {
        //操作停止
        _gui.Pause = true;
        //画面を黒くなる
        _cutScenePanel.SetActive(true);
        //ブロック前のカメラをオンする
        _blockCamera.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        //黒いパネルをオフ
        _cutScenePanel.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        block = true;
        _soundManager.ShutterDownSE();
        yield return new WaitForSeconds(5.0f);
        block = false;
        //黒いパネルをオン
        _cutScenePanel.SetActive(true);
        //ブロック前のカメラをオフする
        _blockCamera.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //黒いパネルをオフ
        _cutScenePanel.SetActive(false);
        block = false;
        //操作停止解除
        _gui.Pause = false;
        _gui.MenuPause = false;
    }

}
