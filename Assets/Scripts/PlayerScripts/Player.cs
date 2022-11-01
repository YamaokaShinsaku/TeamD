using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    // メインステートのインスタンス
    private static readonly StateIdol idol = new StateIdol();
    private static readonly StateMove move = new StateMove();
    private static readonly StateDash dash = new StateDash();
    // その他ステートのインスタンス
    private static readonly StateSpin spin = new StateSpin();
    private static readonly StateJump jump = new StateJump();

    [Tooltip("移動系のステート")][SerializeField] PlayerStateBase state  = idol;
    
    [SerializeField] string nowState = idol.ToString();   // 現在のステートを仮表示 // デバッグ用
    
    // Start()より実行
    public void OnStart()
    {
        state.OnEnter(this, null);
    }

    // Update()より実行
    private void OnUpdate()
    {
        if ((Input.GetKeyDown(jumpKey) || Input.GetButtonDown("Jump" + playerNumber)) && isGround && stamina > subStamina)
        {
            ChangeState(jump);
        }
        else if(Input.GetKeyDown(SpinKey) || Input.GetButtonDown("Fire" + playerNumber))
        {
            ChangeState(spin);
        }
        else
        {
            state.OnUpdate(this);
        }
        HealStamina();
    }

    private void ChangeState(PlayerStateBase _NextState)
    {
        state.OnExit(this, _NextState);
        _NextState.OnEnter(this, state);
        state = _NextState;

        //仮表示の現在のステートを変更
        nowState = state.ToString();
    }

    private void HealStamina()
    {
        if(stamina < maxStamina && state != dash && isGround)
        {
            stamina += 0.1f;
            // 上限を超えてたらもとに戻す
            if(stamina > maxStamina)
            {
                stamina = maxStamina;
            }
        }
    }

    // 移動方向を向かせる関数//Face...向く
    private void FaceFront()
    {
        if(rb.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            Debug.DrawRay(this.transform.position, rb.velocity / 2, Color.blue);
        }
    }
}
