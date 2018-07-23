using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WanderState : IState
{
    private Transform myTransform;
    private float moveAmnt;
    private Action<Vector3> Callback;

    public WanderState(Transform _mytran, float _amnt, Action<Vector3> _cb)
    {
        myTransform = _mytran;
        moveAmnt = _amnt;
        Callback = _cb;
    }

    public void OnStateEnter()
    {
        Debug.Log("wander state enter");
        FindSpot();
    }

    public void OnStateFixedUpdate()
    {

    }

    public void OnStateUpdate()
    {

    }

    public void OnStateExit()
    {

    }

    private void FindSpot()
    {
        float xPos = UnityEngine.Random.Range(-moveAmnt, moveAmnt);
        float zPos = UnityEngine.Random.Range(-moveAmnt, moveAmnt);
        Vector3 pos = new Vector3(xPos, 10f, zPos);

        HitSpot(pos);
    }

    private void HitSpot(Vector3 _pos)
    {
        RaycastHit hit;
        if(Physics.Raycast(_pos, Vector3.down, out hit, 15f))
        {
            if(hit.collider.tag == "Ground")
            {
                Callback(hit.point);
            }
            else
            {
                FindSpot();
            }
        }
    }

}
