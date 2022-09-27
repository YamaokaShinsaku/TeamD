using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player01hate : MonoBehaviour
{
    [SerializeField]
    int add = 0;

    [SerializeField]
    Text player01text;

    [SerializeField]
    Text player02text;


    int NowPlayer01;
    int NowPlayer02;




    public void Awake()
    {
        NowPlayer01 = 0;
        NowPlayer02 = 0;

    }

    bool CountUpFlag = false;

    //ヘイトが上がる関数
    //上がるヘイトの数値とヘイトが上がるプレイヤーナンバーさんを引数にする
    public void HateUp(int addHate,int NumPlayer)
    {
        //ヘイトが上がるプレイヤーさんが１の場合
        if(NumPlayer　== 1)
        {
            NowPlayer01 += addHate;
            player01text.text = NowPlayer01.ToString();

            NowPlayer01 += add;
            player01text.text = NowPlayer01.ToString();


        }
        else if(NumPlayer == 2) //ヘイトが上がるプレイヤーさんが２の場合
        {
            NowPlayer02 += addHate;
            player02text.text = NowPlayer02.ToString();

        }

    }
    //ヘイトが下がる
    public void HateDown(int DownHate, int NumPlayer)
    {
        //ヘイトが上がるプレイヤーさんが１の場合
        if (NumPlayer == 1)
        {
            NowPlayer01 -= DownHate;
            //ヘイトの数値がマイナスだったら0にする
            if(NowPlayer01 < 0)
            {
                NowPlayer01 = 0;
            }
            player01text.text = NowPlayer01.ToString();

        }
        else if (NumPlayer == 2) //ヘイトが上がるプレイヤーさんが２の場合
        {
            NowPlayer02 -= DownHate;
            //ヘイトの数値がマイナスだったら0にする
            if (NowPlayer02 < 0)
            {
                NowPlayer02 = 0;
            }
            player02text.text = NowPlayer02.ToString();

        }

    }

    public void BucketHidden()
    {
    }
}
