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

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 時間を加算
        time += Time.deltaTime;

        // rangeAとrangeBのx座標の範囲内でランダムな値を作成
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな値を作成
        float y = createObj.transform.position.y;
        // rangeAとrangeBのz座標の範囲内でランダムな値を作成
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        // 三秒ごとに生成
        if (time > 3.0f)
        {
            // オブジェクトを生成
            Instantiate(createObj, new Vector3(x, y, z), createObj.transform.rotation);

            time = 0.0f;
        }

        // オブジェクトを生成
        //Instantiate(createObj, new Vector3(x, y, z), createObj.transform.rotation);

        // 時間をリセット
        //time = 0.0f;
    }
}
