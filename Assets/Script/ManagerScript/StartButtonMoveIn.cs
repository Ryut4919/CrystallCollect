using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonMoveIn : MonoBehaviour
{
    //ボダンを画面に入る速度
    [SerializeField]
    private float MoveInSpeed=1.0f;

    //ボダンを画面に入る位置
    [SerializeField]
    private Vector3 MovePosition;


    public bool Return = false;

    //ボダンの最初位置を記録用
    private Vector3 startpos;

    private void Start()
    {
        startpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Return)
        {
            transform.position = Vector3.Lerp(transform.position, MovePosition, MoveInSpeed * Time.deltaTime);
        }
        else 
        {
            transform.position = Vector3.Lerp(transform.position, startpos, MoveInSpeed * Time.deltaTime);
        }
        
    }
}
