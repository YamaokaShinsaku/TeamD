using UnityEngine;

public partial class Player
{
    /// <summary>
    /// 待機状態
    /// 
    /// この状態からの遷移先は
    /// 移動状態
    /// </summary>
    public class StateIdol : PlayerStateBase
    {
        public override void OnUpdate(Player owner)
        {

            //移動状態はスタミナが回復する
            GameObject StaminaUp = GameObject.Find("PlayerStamina");
            StaminaUp.GetComponent<playerStamina>().StaminaUp(0.1f, owner.GetComponent<Player>().GetPlayerNumber());


            // 移動状態に遷移
            if (owner.inputValue.x != 0 || owner.inputValue.y != 0)
            {
				owner.ChangeState(move);
            }
        }
    }
}