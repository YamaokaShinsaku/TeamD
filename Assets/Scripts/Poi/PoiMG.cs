using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiMG : MonoBehaviour
{
    public PoiMove mMove;
    public Chase mChase;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        mChase.ChaseUpdate();
        //mMove.MoveUpdate();
    }


    /// <summary>
    /// コライダーに入ったら
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // タグが『Player』であったら
        if (other.gameObject.tag == "Player")
        {
            // ターゲットをランダムで変更する
            mChase.target = mChase.Players[Random.Range(0, mChase.Players.Length)].transform;
        }
    }
}

