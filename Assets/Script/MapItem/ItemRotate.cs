using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリスタルを回転する
/// </summary>
public class ItemRotate : MonoBehaviour
{
    [SerializeField]
    private float SelfRotateY = 4;

    void Update()
    {
        SelfRotate();
    }

    private void SelfRotate() 
    {
        transform.Rotate(0, SelfRotateY, 0, Space.World);
    }
}
