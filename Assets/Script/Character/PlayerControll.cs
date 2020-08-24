using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクタの移動処理
/// </summary>
public class PlayerControll : MonoBehaviour
{

    public float MoveSpd;//移動速度
    [SerializeField]
    private GameManager _manager;
    [SerializeField]
    private GUIScript _gui;

    private CharacterController _Controller;
    private Animator _animator;

    private Vector3 Dir;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _Controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_manager.GameOver&&!_manager.GameClear&!_gui.Pause) 
        {
            PlayerMove();
        }
        
    }

    /// <summary>
    /// プレイヤー移動操作
    /// </summary>
    private void PlayerMove() 
    {
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 0.5f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 0.5f;

        //Dir = new Vector3(x, 0, z);

        float xDir = Input.GetAxis("Horizontal") * MoveSpd;
        float zDir = Input.GetAxis("Vertical") * MoveSpd;

        Vector3 ForwardMove = transform.forward * zDir;
        Vector3 RightMove = transform.right * xDir;

        _Controller.SimpleMove(ForwardMove + RightMove);

        Dir = new Vector3(xDir, 0, zDir);

        if (Dir.sqrMagnitude > 0)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle", true);
        }
        
    } 
}
