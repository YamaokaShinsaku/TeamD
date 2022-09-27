using UnityEngine;

public partial class Player
{
    [Header("“–‚½‚è”»’è")]
    [Tooltip("ƒ_ƒbƒVƒ…UŒ‚‚ ‚½‚è”»’è")][SerializeField] Collider dashColl;
    [Tooltip("‰ñ“]UŒ‚“–‚½‚è”»’è")][SerializeField] Collider spinColl;

    private void OnCollisionEnter(Collision collision)
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != this.gameObject && other.tag == this.tag)
        if(state == dash)
        {
                mgr.AttackProc(this.gameObject, other.gameObject, PlayerMgr.AtkState.Dash);
        }
        else if(state == spin)
        {
                mgr.AttackProc(this.gameObject, other.gameObject, PlayerMgr.AtkState.Spin);
        }
    }
}