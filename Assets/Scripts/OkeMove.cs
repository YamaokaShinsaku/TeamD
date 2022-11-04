using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkeMove : MonoBehaviour
{
    [SerializeField]
    //public Transform target;
    public float speed;

    private int XZRand;
    Vector3 Point;
    float MaxX = 116.0f;
    float MinX = -117.0f;
    float MaxZ = 53.0f;
    float MinZ = -56.0f;

    // Start is called before the first frame update
    void Start()
    {
        //移動地点の初期化(Y座標は固定)
        Point = new Vector3(0.0f, 17.12f, 0.0f);

        //移動地点をランダムに取得
        RandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //移動速度
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, Point, step);

        Vector3 pos = Point;

        //float test = Vector3.Distance(target.position, pos);
        transform.LookAt(pos);

        //移動地点に着いたら移動地点をランダムに変更する
        if (Vector3.Distance(transform.position, pos) < 0.5f)
        {
            RandomPoint();
        }
    }

    //移動地点をランダムに決める関数
    void RandomPoint()
    {
        XZRand = Random.Range(0, 4);

        if (XZRand == 0) //下方向
        {
            Point.x = Random.Range(MinX, MaxX);
            Point.z = MinZ;
        }
        else if (XZRand == 1) //上方向
        {
            Point.x = Random.Range(MinX, MaxX);
            Point.z = MaxZ;
        }
        else if (XZRand == 2) //左方向
        {
            Point.x = MinX;
            Point.z = Random.Range(MinZ, MaxZ);
        }
        else if (XZRand == 3) //右方向
        {
            Point.x = MaxX;
            Point.z = Random.Range(MinZ, MaxZ);
        }
    }
}
