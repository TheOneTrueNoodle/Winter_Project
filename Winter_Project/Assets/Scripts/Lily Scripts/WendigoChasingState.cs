using UnityEngine;

public class WendigoChasingState : WendigoBaseState
{
    public override void EnterState(WendigoStateManager wendigo)
    {
        
    }

    public override void UpdateState(WendigoStateManager wendigo)
    {
        wendigo.transform.position = Vector3.MoveTowards(wendigo.transform.position, wendigo.player.position,
            wendigo.speed * Time.deltaTime * 2);
    }

    public override void OnCollide(WendigoStateManager wendigo)
    {
        
    }
    
    public override void OnTrig(WendigoStateManager wendigo, Collider2D other)
    {
        
    }
    
    public override void OnTrigExit(WendigoStateManager wendigo)
    {
        
    }
}
