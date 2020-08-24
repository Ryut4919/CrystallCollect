using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player;//プレイヤーの位置を取る

    private void LateUpdate()
    {
        Vector3 Pos = player.transform.position;
        Pos.y = transform.position.y;
        transform.position = Pos;
    }
}
