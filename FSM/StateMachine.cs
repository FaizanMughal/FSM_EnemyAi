using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private IState currentState;

    public void ChangeStates(IState _state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = _state;
        currentState.OnStateEnter();
    }

    public void UpdateStates()
    {
        currentState.OnStateUpdate();
    }

    public void FixedUpdateStates()
    {
        currentState.OnStateFixedUpdate();
    }

}
