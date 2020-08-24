using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField]
    private GameManager _manager;

    [SerializeField]
    private SoundManager _soundManager;

    private void OnTriggerEnter(Collider other)
    {
        //クリスタルを当たった場合
        if (other.tag == "GoalPoint") 
        {
            other.gameObject.SetActive(false);
            _manager.GetPoint();
            _soundManager.GetPointSE();
        }

        //クリアカートを当たった場合
        if (other.tag == "ClearZone") 
        {
            other.gameObject.SetActive(true);
            _manager.GameClear = true;
            _soundManager.GameClearSE();
        }
    }

}
