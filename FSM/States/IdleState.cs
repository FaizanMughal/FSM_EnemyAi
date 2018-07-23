using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IdleState : IState
{

    private float idleTimer;
    private float timer; //local use only
    private Action CallBack;//----a function....

    public IdleState(float _idleTimer, Action _cb)
    {
        idleTimer = _idleTimer;
        CallBack = _cb;
    }

    public void OnStateEnter()
    {
        Debug.Log("On state enter....idel");
    }

    public void OnStateExit()
    {

    }

    public void OnStateFixedUpdate()
    {

    }

    public void OnStateUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= idleTimer)
        {
            CallBack();
        }
    }
}
