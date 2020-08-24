using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

/// <summary>
/// ステージを作る
/// </summary>
public class MazeCreator : MonoBehaviour
{
    public int MapSize = 7;//マップのサイズ
    int[,] maze;//マップ作成　0＝壁、1＝道
    int WallCount = 0;//壁作成した数

    [SerializeField]
    GameObject WallObj;//壁入れ
    [SerializeField]
    GameObject GroundObj;//床入れ
    [SerializeField]
    GameObject GoalObj; //終点入れ

    void Start()
    {
        //マップ作成終了条件
        int endNum = ((MapSize + 1) / 2) * ((MapSize + 1) / 2) - 1;

        maze = new int[MapSize + 2, MapSize + 2];

        while (endNum > WallCount)
        {
            int x = Random.Range(0, (MapSize + 1) / 2) * 2;
            int y = Random.Range(0, (MapSize + 1) / 2) * 2;

            if (WallCount == 0) //最初の場合
                maze[x + 1, y + 1] = 1;
            if (maze[x + 1, y + 1] == 1) { }
            Dig(x, y, 0);
        }

        Showmap();//マップ表示

        Instantiate(GoalObj, new Vector3(MapSize, 0, MapSize), Quaternion.identity);//ゴール作成

    }

    private void Dig(int x,int y,int OldVec)
    {
        int[] vx = { 0, 2, 0, -2 };
        int[] vy = { -2, 0, 2, 0 };

        bool retFlag = false;

        //4方向
        int r = Random.Range(0, 4);

        //マップの使えないところ
        if (r == 0 && y <= 0)
            retFlag = true;
        if (r == 1 && (x + 2) >= MapSize) 
            retFlag = true;
        if (r == 2 && (y + 2) >= MapSize)
            retFlag = true;
        if (r == 3 && x <= 0)
            retFlag = true;

        //やり直し
        if (retFlag)
        {
            Dig(x, y, OldVec);
            return;
        }

        //マップの使えるところ
        if (maze[x + 1 + vx[r], y + 1+ vy[r]] == 0)
        {
            maze[x + 1 + vx[r], y + 1 + vy[r]] = 1;
            maze[x + 1 + vx[r] / 2, y + 1  + vy[r] / 2] = 1;
            WallCount++;

            Dig(x + vx[r], y + vy[r], r);
        }
    }

    private void Showmap() 
    {
        GameObject obj = new GameObject(); //格納用
        obj.name = "M";

        for (int i = 0; i < MapSize + 2; i++) 
        {
            for (int j = 0; j < MapSize + 2; j++) 
            {
                if (maze[i, j] == 0)
                {
                    Instantiate(WallObj, new Vector3(i, 0, j), Quaternion.identity).transform.parent = obj.transform;
                }
                else
                {
                    Instantiate(GroundObj, new Vector3(i, 0, j), Quaternion.identity).transform.parent = obj.transform;
                }
            }
        }
    }
}
