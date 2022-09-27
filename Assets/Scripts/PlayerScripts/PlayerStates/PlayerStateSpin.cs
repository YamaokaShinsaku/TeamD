using UnityEngine;

public partial class Player
{
    public class StateSpin : PlayerStateBase
    {
        public override void OnEnter(Player owner, PlayerStateBase prevState)
        {
            owner.timeCounter = 0;
            owner.spinColl.enabled = true;
        }
        public override void OnUpdate(Player owner)
        {
            owner.timeCounter += Time.deltaTime;
            if(owner.timeCounter > owner.spinTimeOnce)
            {
                owner.spinColl.enabled = false;
                owner.ChangeState(idol);
            }
        }
    }
}