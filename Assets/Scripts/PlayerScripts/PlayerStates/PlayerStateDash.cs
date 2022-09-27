using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    public class StateDash : PlayerStateBase
    {
        bool isDash;
        float dashTimer;

        public override void OnEnter(Player owner, PlayerStateBase prevState)
        {
            isDash = false;
            dashTimer = 0;
        }

        public override void OnUpdate(Player owner)
        {
            // ダッシュフラグが折れていたら
            if (!isDash)
            {
                // ダッシュ条件を満たしている
                if (Input.GetKey(owner.dashKey) && owner.isGround && owner.stamina > owner.subStamina)
                {
                    // コストを支払ったら
                    owner.stamina -= owner.subStamina;
                    // フラグが立つ
                    isDash = true;
                    // 当たり判定を有効化
                    owner.dashColl.enabled = true;

                    //攻撃が当たったら当たった側のスタミナを減らす
                    GameObject StaminaDown = GameObject.Find("PlayerStamina");
                    StaminaDown.GetComponent<playerStamina>().StaminaDown(0.5f, owner.GetComponent<Player>().GetPlayerNumber());
                }
                // 満たしてない
                else if(!Input.GetKey(owner.dashKey) || !owner.isGround || owner.stamina <= owner.subStamina)
                {
                    // ダッシュ攻撃処理を終了する
                    owner.dashColl.enabled = false;
                    owner.ChangeState(move);
                }
            }
            // ダッシュ処理を行う
            owner.MoveProc(owner.inputValue, owner.velocity, owner.maxDashVel, owner.dashACC);
            // 移動方向を向く処理
            owner.FaceFront();
            // 時間を計測する
            dashTimer += Time.deltaTime;
            // 時間が一回のダッシュの時間を超えていたら
            if(dashTimer > owner.dashTimeOnce)
            {
                // フラグを折る
                isDash = false;
            }
        }
    }
}