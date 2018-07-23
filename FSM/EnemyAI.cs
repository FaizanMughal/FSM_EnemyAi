using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {


    public StateMachine sm;

    private NavMeshAgent myAgent;
    public float speed;
    public float lookDistance;
    public float idleTimer;
    public float minDist;
    private Vector3 moveToPos;
    public float moveAmnt;


    private IdleState idle;
    private LookState look;
    private MoveState move;
    private WanderState wander;



    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        Idle();
    }

 

    private void Update()
    {
        sm.UpdateStates();
    }

    private void FixedUpdate()
    {
        sm.FixedUpdateStates();
    }

    //-----------------------State Changers-----------------------
    private void Idle()
    {
        sm.ChangeStates(NewIdle());
    }

    private void Look()
    {
        sm.ChangeStates(NewLook());
    }

    private void Move()
    {
        sm.ChangeStates(NewMove());
    }

    private void Wander()
    {
        sm.ChangeStates(NewWander());
    }

    //-----------------------Callbacks-------------------------
    public void IdleCallback()
    {
        Look();
    }

    private void MoveCallBack()
    {
        Idle();
    }

    private void LookCallback(bool value, GameObject _plr)
    {
        if (value)
        {
            moveToPos = _plr.transform.position;
            Move();
        }
        else
        {
            Wander();
        }
    }

    private void WanderCallBack(Vector3 _pos)
    {
        moveToPos = _pos;
        Move();
    }

    //-----------------------New States------------------------
    private IdleState NewIdle()
    {
        idle = new IdleState(idleTimer, IdleCallback);
        return idle;
    }

    private LookState NewLook()
    {
        look = new LookState(transform, lookDistance, "Player", LookCallback);
        return look;
    }

    private MoveState NewMove()
    {
        move = new MoveState(transform, moveToPos, myAgent, speed, minDist, MoveCallBack);
        return move;
    }

    private WanderState NewWander()
    {
        wander = new WanderState(transform, moveAmnt, WanderCallBack);
        return wander;
    }

}
