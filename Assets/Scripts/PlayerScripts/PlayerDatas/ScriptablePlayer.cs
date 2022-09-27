using UnityEngine;

// Assets/Create/ScriptableObjects/CreateScriptablePlayerの項目を選択することで
// Dataという名前でアセット化されてassetsフォルダに入る。
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateScriptablePlayer")]

public class ScriptablePlayer : ScriptableObject
{
    // Variables
    [Tooltip("名前")]               public string Name = "Anonymous";
    [Tooltip("体力")]               public float Stamina;
    [Tooltip("体力減少量")]         public float StaminaSubValue;

    [Header("通常移動")]
    [Tooltip("通常移動の最高速度")] public float MaxNormalVelocity;
    [Tooltip("通常移動の加速度")]   public float NormalAcceleration;
    
    [Header("ダッシュ")]
    [Tooltip("1回のダッシュ時間")]  public float DashTimeOnce;
    [Tooltip("ダッシュの最高速度")] public float MaxDashVelocity;
    [Tooltip("ダッシュの加速度")]   public float DashAcceleration;
    [Tooltip("ダッシュ攻撃力X:飛ぶ方向の力/Y:上向きの力")]     public Vector2 DashAtkForce;

    [Header("ジャンプ")]
    [Tooltip("ジャンプ力")]         public float JumpPower;

    [Header("回転")]
    [Tooltip("回転時間")]           public float SpinTimeOnce;
    [Tooltip("回転攻撃力X:飛ぶ方向の力/Y:上向きの力")]         public Vector2 SpinAtkForce;
}