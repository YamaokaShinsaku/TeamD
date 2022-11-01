using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    // プレイヤー
    public GameObject[] Players;
    // NavMeshAgent
    private NavMeshAgent agent;
    // 追う対象を格納
    public Transform target;

    public poiColor mPoiColor;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // タグからプレイヤーを探す
        Players = GameObject.FindGameObjectsWithTag("Player");
        // ターゲットをランダムで選ぶ
        target = Players[Random.Range(0, Players.Length)].transform;
        mPoiColor.ColorUpdate(target, Players[0], Players[1]);
    }

    // Update is called once per frame
    public void ChaseUpdate()
    {
        //Count += Time.deltaTime;
        //Debug.Log(UpCount);
        // ターゲットのポジションに向かう
        agent.destination = target.position;
        //if(UpCount <= 5)
        //{
        //    agent.destination = new Vector3(0, 2.5f, 0);
        //}
    }

    /// <summary>
    /// コライダーに入ったら
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // タグが『Player』であったら
        if(other.gameObject.tag == "Player")
        {
            // ターゲットをランダムで変更する
            target = Players[Random.Range(0, Players.Length)].transform;
        }
        mPoiColor.ColorUpdate(target, Players[0], Players[1]);
    }
}