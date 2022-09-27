// プレイヤーを管理するスクリプト
// プレイヤーとは別に管理オブジェクトにアタッチして使用する。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    [Tooltip("プレイヤー数")][SerializeField] const int player_num = 2;
    [Tooltip("プレイヤー情報")][SerializeField] List<GameObject> players;
    [Tooltip("プレイヤーのC#")][SerializeField] List<Player> playerCSs;

    // 攻撃した、攻撃当たったときに使用する
    [SerializeField] float stopTime = 0.1f;                 // 攻撃が当たった時に停止する時間
    [Tooltip("タイマー")] float stopTimer;  // 攻撃が当たった時に使用するタイマー
    GameObject hitter;
    public enum AtkState
    {
        Dash,
        Spin
    }
    private AtkState atkState;
    Vector3 atkForce;                           // 関数が呼ばれたときに飛ばす力が入る

    // 点滅処理
    float blinkTime = 1.0f;         // 点滅時間
    float blinkInterval = 0.1f;     // 点滅間隔
    float blinkNextTime = 0;        // 次に点滅する時間
    float blinkTimer = 0;           // 点滅時に使用するタイマー

    [SerializeField] float disableTime = 0.1f;  // 攻撃無効化できる時間

    private void Awake()
    {
        //未設定があればAwake最後にデバッグ終了
        bool exitFlag = false;

        for (int i = 0; i < player_num; ++i)
        {
            if (!players[i] || players[i].tag != "Player")
            {
                Debug.LogError("プレイヤーを配列にセットできてないか、プレイヤーにタグがついていません。");
                exitFlag = true;
            }
            if(!playerCSs[i])
            {
                Debug.LogError("プレイヤーのC#がセットできてません。");
                exitFlag = true;
            }
        }

        if (exitFlag)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
    private void Start()
    {
        // プレイヤーの開始
        for (int i = 0; i < player_num; ++i)
        {
            playerCSs[i].PlayerStart();
        }
    }
    private void Update()
    {
        if (stopTimer == 0)
        {
            // プレイヤーの更新
            for (int i = 0; i < player_num; ++i)
            {
                playerCSs[i].PlayerUpdate();
            }

            // 点滅処理
            if(blinkTimer != 0)
            {
                // 点滅するか判定して
                if(blinkTimer <= blinkNextTime)
                {
                    // 次に点滅する時間を設定して
                    blinkNextTime -= blinkInterval;
                    if(hitter.GetComponent<MeshRenderer>().enabled)
                    {
                        hitter.GetComponent<MeshRenderer>().enabled = false;
                    }
                    else
                    {
                        hitter.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                // 時間を経過させていき
                blinkTimer -= Time.deltaTime;
                // 時間が越えたら
                if(blinkTimer <= 0)
                {
                    // 点滅を終了
                    blinkTimer = 0;
                    hitter.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
        else
        {
            stopTimer -= Time.deltaTime;
            // プレイヤーの動きを停止する
            for (int i = 0; i < player_num; ++i)
            {
                players[i].GetComponent<Rigidbody>().isKinematic = true;
            }
            // 停止時間を過ぎたら0にしてあげることで、プレイヤーの更新に戻る
            if (stopTimer <= 0.0f)
            {
                stopTimer = 0;
                // プレイヤーの動きを再開する
                for (int i = 0; i < player_num; ++i)
                {
                    players[i].GetComponent<Rigidbody>().isKinematic = false;
                }
                // 攻撃を受けたオブジェクトに作成した力を加える
                hitter.GetComponent<Rigidbody>().AddForce(atkForce);
            }
        }
    }

    // 攻撃処理
    public void AttackProc(GameObject _Attacker, GameObject _Hitter, AtkState _AtkState)
    {
        // 飛ばすときの処理のために記録しておく
        hitter = _Hitter;
        atkState = _AtkState;

        // -----攻撃を受けたオブジェクトの向きを変える処理-----
        Vector3 dir = _Hitter.transform.position - _Attacker.transform.position;
        _Hitter.transform.rotation = Quaternion.Euler(dir);

        /// -----攻撃を受けたオブジェクトが飛ぶ力を求める処理-----
        Vector3 force;
        // xzを正規化
        force.y = 0;
        force = dir.normalized;
        // 飛ばす力を正規化したベクトルに乗算
        if (atkState == AtkState.Dash)
        {
            force *= _Attacker.GetComponent<Player>().GetPlayerData().DashAtkForce.x;
            force.y = _Attacker.GetComponent<Player>().GetPlayerData().DashAtkForce.y;
        }
        else
        {
            force *= _Attacker.GetComponent<Player>().GetPlayerData().SpinAtkForce.x;
            force.y = _Attacker.GetComponent<Player>().GetPlayerData().SpinAtkForce.y;
        }
        // 力を記録しておく
        atkForce = force;
        // 停止タイマーをセットする
        stopTimer = stopTime;
        // 点滅タイマーをセット
        blinkTimer = blinkTime;
        // 次の点滅時間をセット
        blinkNextTime = blinkTime;

        //攻撃が当たったら当たった側のスタミナを減らす
        GameObject StaminaDown = GameObject.Find("PlayerStamina");
        StaminaDown.GetComponent<playerStamina>().StaminaDown(10.0f, hitter.GetComponent<Player>().GetPlayerNumber());
        //攻撃が当たったらヘイトも上げる
        GameObject HateUp = GameObject.Find("player01hate");
        HateUp.GetComponent<player01hate>().HateUp(10, hitter.GetComponent<Player>().GetPlayerNumber());
    }
    
    // ゲームオブジェクトのオイラー角を取得する関数
    public Vector3 GetEuler(GameObject _Objct)
    {
        Quaternion qua = _Objct.transform.rotation;
        return qua.eulerAngles;
    }
}