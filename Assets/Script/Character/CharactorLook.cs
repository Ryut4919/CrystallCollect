using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// カメラの向いている方向
/// </summary>
public class CharactorLook : MonoBehaviour
{
    //マウス移動速度
    [SerializeField] private float mouseSensitivity;
    //キャラクターコントローラーを取る
    [SerializeField] private CharacterController _charactor;
    //キャラクター位置を取る
    [SerializeField] private Transform PlayerBody;
    [SerializeField] private GameManager _manager;
    [SerializeField] private GUIScript _gui;

    private float XClamp;
    private bool StopCameraFollow;
    void Start()
    {
        XClamp = 0.0f;
        StopCameraFollow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_manager.GameOver && !_manager.GameClear) 
        {
            if (!_gui.Pause)//ゲーム停止じゃない
            {
                CameraRotation();
            }
            
        }
        
    }

    /// <summary>
    /// カメラの回転
    /// </summary>
    private void CameraRotation() 
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        XClamp += mouseY;

        if (XClamp > 90.0f)
        {
            XClamp = 90.0f;
            mouseY = 0.0f;
            XAxisRotationToValue(270.0f);
        }
        else if (XClamp<-90.0f) 
        {
            XClamp = -90.0f;
            mouseY = 0.0f;
            XAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);

        PlayerBody.Rotate(Vector3.up, mouseX);

    }

    private void XAxisRotationToValue(float Value) 
    {
        Vector3 eulerAngle = transform.eulerAngles;
        eulerAngle.x = Value;
        transform.eulerAngles = eulerAngle;
    }
}
