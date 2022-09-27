using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    [Tooltip("プレイヤー管理")][SerializeField] PlayerMgr mgr;
    [Tooltip("情報")][SerializeField] ScriptablePlayer data;
    [Tooltip("プレイ番号")][SerializeField] short playerNumber = 1;
    [SerializeField] KeyCode dashKey = KeyCode.LeftShift;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode SpinKey = KeyCode.Return;
    [Tooltip("接地判定距離")][SerializeField] float groundJudgDist;

    //設定項目
    Rigidbody rb;           // 物理
    float     maxStamina;   // 最大体力
    [SerializeField]float     stamina;      // 体力
    float     subStamina;   // 体力減少量
    float     dashTimeOnce; // 一回のダッシュで強制的にダッシュになる時間
    float     maxNormalVel; // 通常移動の最高速度
    float     normalACC;    // 通常移動の加速度
    float     maxDashVel;   // ダッシュの最高速度
    float     dashACC;      // ダッシュの加速度
    float     jumpPower;    // ジャンプ力
    float     spinTimeOnce; // 1回の回転攻撃にかかる時間
    public ScriptablePlayer GetPlayerData() { return data; }
    public int GetPlayerNumber() { return playerNumber; }


    //処理更新項目
    Vector2   inputValue;   // XYの入力量
    float     velocity;     // 移動速度
    bool      isGround;     // 接地判定
    [SerializeField]float     timeCounter;  // 時間計測用タイマー

    private void Awake()
    {
        //未設定があればAwake最後にデバッグ終了
        bool exitFlag = false;

        if (!(rb = GetComponent<Rigidbody>()))
        {
            Debug.LogError("物理挙動コンポーネントが未設定");
            exitFlag = true;
        }

        //タグ設定確認
        //タグは設定されているか？
        if (tag == "Untagged")
        {
            Debug.LogError(this.gameObject.name + "オブジェクトのタグが設定されていません。");
            exitFlag = true;
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

    public void PlayerStart()
    {
        mgr = GameObject.Find("PlayerMgr").GetComponent<PlayerMgr>();
        rb = GetComponent<Rigidbody>();
        stamina      = maxStamina =data.Stamina;
        subStamina   = data.StaminaSubValue;
        dashTimeOnce = data.DashTimeOnce;
        maxNormalVel = data.MaxNormalVelocity;
        normalACC    = data.NormalAcceleration;
        maxDashVel   = data.MaxDashVelocity;
        dashACC      = data.DashAcceleration;
        jumpPower    = data.JumpPower;
        spinTimeOnce = data.SpinTimeOnce;
        // 当たり判定を無効化
        dashColl.enabled = false;
        spinColl.enabled = false;
        OnStart();      // プレイヤーの開始
    }

    public void PlayerUpdate()
    {
        CheckIsGround();// 接地管理
        CheckXYInput(); // スティックや移動キーの入力更新
        OnUpdate();     // プレイヤーの更新
    }

    /// <summary>
    /// XYの入力量を取得する
    /// </summary>
    private void CheckXYInput()
    {
        inputValue.x = Input.GetAxis("Horizontal" + playerNumber);
        inputValue.y = Input.GetAxis("Vertical" + playerNumber);
    }

    /// <summary>
    /// 接地判定を取得
    /// </summary>
    private void CheckIsGround()
    {
        Vector3 rayPos = transform.position + new Vector3(0, 0, 0);
        Ray ray = new Ray(rayPos, Vector3.down);
        isGround = Physics.Raycast(ray, groundJudgDist);
    }
}