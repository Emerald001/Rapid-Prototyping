using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStateMachine : MonoBehaviour
{
    public IState currentState;
    public GameObject firstState;

    public void OnStart() {
        currentState = firstState.GetComponent<IState>();
    }

    void Update() {
        if(currentState != null)
            currentState.OnUpdate();
    }

    public void EditState(GameObject stateHolder) {
        var state = stateHolder.GetComponent<IState>();

        if (currentState != state) {
            currentState.OnExit();
            currentState = state;
            currentState.OnEnter();
        }
    }
}