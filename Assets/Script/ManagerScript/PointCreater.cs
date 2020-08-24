using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// メインステージにクリスタルの位置をランダム表示
/// </summary>
public class PointCreater : MonoBehaviour
{
    //表示可能の位置を保存用
    [SerializeField]
    private Transform[] _pointposition;

    [SerializeField]
    private GameObject _pointObj;

    //マップクリア必要のポイント数
    [SerializeField]
    private int _point;

    //ランダムした数字を保存
    private List<int> SaveRandomNumber = new List<int>();

    private void Awake()
    {
        for (int j = 0; j <_pointposition.Length; ++j)
        {
            SaveRandomNumber.Add(j);
        }

        for (int i = 0; i < _point; ++i) 
        {
            int n = Random.Range(0, SaveRandomNumber.Count - 1);
            GameObject _obj=  Instantiate(_pointObj, _pointposition[n].position, Quaternion.identity);
            _obj.transform.SetParent(GameObject.Find("PointPlace").transform);
            SaveRandomNumber.RemoveAt(n);
        }
        
    }


}
