using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoi : MonoBehaviour
{
    [SerializeField]
    private GameObject createObj;   //生成するオブジェクト

    [SerializeField]
    private Transform rangeA;   // 生成範囲（左上）

    [SerializeField]
    private Transform rangeB;   // 生成範囲（右下）

    public float deltaTime;     // 経過時間
    public float createTime;    // 生成時間（createTime秒後に生成する）
    public int nowCreateCount;  // 現在の生成個数
    public int maxCreateCount;  // 最大生成個数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 時間を加算
        deltaTime += Time.deltaTime;

        // rangeAとrangeBのx座標の範囲内でランダムな値を作成
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな値を作成
        float y = createObj.transform.position.y;
        // rangeAとrangeBのz座標の範囲内でランダムな値を作成
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        // 生成個数が最大値を超えていないとき
        if(nowCreateCount < maxCreateCount)
        {
            // 三秒ごとに生成
            if (deltaTime > createTime)
            {
                // オブジェクトを生成
                Instantiate(createObj, new Vector3(x, y, z), createObj.transform.rotation);

                // 経過時間を０にして生成数を加算
                deltaTime = 0.0f;
                nowCreateCount++;
            }
        }
        else
        {
            // 計測終了
            deltaTime = 0.0f;
        }
    }
}
