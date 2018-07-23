using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LookState : IState
{

    private Transform myTransform;
    private float lookDistance;
    private string playerTag;
    private Action<bool, GameObject> Callback;

    public LookState(Transform _tran, float _look, string _tag, Action<bool, GameObject> _cb)
    {
        myTransform = _tran;
        lookDistance = _look;
        playerTag = _tag;
        Callback = _cb;
    }

    public void OnStateEnter()
    {
        Debug.Log("Look enter");
        Look();
    }

    public void OnStateUpdate()
    {

    }

    public void OnStateFixedUpdate()
    {

    }

    public void OnStateExit()
    {

    }

    private void Look()
    {
        Collider[] coll = Physics.OverlapSphere(myTransform.position, lookDistance);

        for (int i = 0; i < coll.Length; i++)
        {
            if(coll[i].gameObject.tag == playerTag)
            {
                //found player
                Callback(true, coll[i].gameObject);
            }
        }

        //havnt fount the player
        Callback(false, null);
    }

//end o class
}
