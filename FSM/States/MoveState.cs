using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class MoveState : IState
{
    private Transform myTransform;
    private Vector3 moveToPos;
    private NavMeshAgent myAgent;
    private float speed;
    private float minDist;
    private Action Callback;

    public MoveState(Transform _tran, Vector3 _pos, NavMeshAgent _agt, float _speed, float _mindist, Action _cb)
    {
        myTransform = _tran;
        moveToPos = _pos;
        myAgent = _agt;
        speed = _speed;
        minDist = _mindist;
        Callback = _cb;
    }

    public void OnStateEnter()
    {
        myAgent.speed = speed;
        Debug.Log("move enter");
    }
    
    public void OnStateUpdate()
    {
        if (IsClose())
        {
            Callback();
        }
        else
        {
            myAgent.destination = moveToPos;
        }
    }

    public void OnStateFixedUpdate()
    {

    }

    public void OnStateExit()
    {

    }


    private bool IsClose()
    {
        float d = Vector3.Distance(myTransform.position, moveToPos);
        if (d <= minDist)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


//end o class
}
