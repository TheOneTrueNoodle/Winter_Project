using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendigoStateManager : MonoBehaviour
{

    public Transform player;
    public float speed = 3;
    public Collider2D trackingTrigger;
    public Collider2D pauseTrigger;
    public float timer = 3f;
    public bool timerRunning = false;
    
    WendigoBaseState currentState;
    public WendigoTrackingState TrackingState = new WendigoTrackingState();
    public WendigoChasingState ChasingState = new WendigoChasingState();
    public WendigoHidingState HidingState = new WendigoHidingState();
    public WendigoPauseState PauseState = new WendigoPauseState();
    public PlayerMovement PlayerMovement = new PlayerMovement();


    // Start is called before the first frame update
    void Start()
    {
        currentState = TrackingState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        Debug.Log("Current state = " + currentState);
    }

    public void SwitchState(WendigoBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        currentState.OnTrig(this);
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        currentState.OnTrigExit(this);
    }
}   
