using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiMove : MonoBehaviour
{
    //Animatorをanimという変数で定義する
    [SerializeField]
    private Animator anim;
    private float mTime;
    private float mScoopTime;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = anim.GetComponent<Animator>();
        mTime = 0.0f;
        mScoopTime = 5.0f;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void MoveUpdate()
    {
        mTime += Time.deltaTime;
        // 時間経過したら
        if (mTime > mScoopTime)
        {
            // Bool型のパラメーターをTrueにする
            anim.SetBool("scoop", true);
            mTime = 0.0f;
            //mScoopTime -= 1;
        }
        else
        {
            // bool型のパラメーターをfalseにする
            anim.SetBool("scoop", false);
        }
    }
}
