using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoTrackingState : WendigoBaseState
{
    private WendigoStateManager stateManager;

    public override void EnterState(WendigoStateManager wendigo)
    {
    }

    public override void UpdateState(WendigoStateManager wendigo)
    {
        wendigo.transform.position = Vector3.MoveTowards(wendigo.transform.position, wendigo.player.position,
            wendigo.speed * Time.deltaTime);

    }

    public override void OnCollide(WendigoStateManager wendigo)
    {

    }

    public override void OnTrig(WendigoStateManager wendigo)
    {
        wendigo.trackingTrigger.enabled = false;
        wendigo.pauseTrigger.enabled = true;
        wendigo.PlayerMovement.isInTrigger = true;
        wendigo.SwitchState(wendigo.PauseState);
    }

    public override void OnTrigExit(WendigoStateManager wendigo)
    {
    }

}

