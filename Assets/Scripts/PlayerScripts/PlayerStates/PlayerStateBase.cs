/// <summary>
/// PlayerStateの抽象クラス
/// </summary>
public abstract class PlayerStateBase
{
    /// <summary>
    /// ステート開始時に実行
    /// </summary>
    public virtual void OnEnter(Player owner, PlayerStateBase prevState) { }

    /// <summary>
    /// 毎フレーム実行
    /// </summary>
    public virtual void OnUpdate(Player owner) { }

    /// <summary>
    /// ステート終了時に実行
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="nextState"></param>
    public virtual void OnExit(Player owner, PlayerStateBase nextState) { }
}