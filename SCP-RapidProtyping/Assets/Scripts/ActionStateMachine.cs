using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStateMachine : MonoBehaviour
{
    public State currentState;

    void Start()
    {
        
    }

    void Update()
    {
        if(currentState != null)
            currentState.OnUpdate();
    }

    void ChangeState(State state) {
        if(currentState != state) {
            currentState = state;
        }
    }
}