using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoPauseState : WendigoBaseState
{
    public override void EnterState(WendigoStateManager wendigo)
    {
        wendigo.timerRunning = true;
    }

    public override void UpdateState(WendigoStateManager wendigo)
    {
        if (wendigo.timerRunning == true)
        {
            wendigo.timer -= Time.deltaTime % 60f;
            if (wendigo.timer >= 0)
            {
                Debug.Log("timer running");
            }
            else
            {
                Debug.Log("timer done");
                wendigo.timerRunning = false;
            }
        }

        if (wendigo.timer <= 0f)
        {
            wendigo.SwitchState(wendigo.ChasingState);
        }
    }

    public override void OnCollide(WendigoStateManager wendigo)
    {
        
    }
    
    public override void OnTrig(WendigoStateManager wendigo)
    {
        
    }

    public override void OnTrigExit(WendigoStateManager wendigo)
    {
        wendigo.pauseTrigger.enabled = false;
        wendigo.trackingTrigger.enabled = true;
        wendigo.PlayerMovement.isInTrigger = false;
        wendigo.timerRunning = false;
        wendigo.timer = 3f;
        wendigo.SwitchState(wendigo.TrackingState);
    }
}
