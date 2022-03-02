using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStateMachine : MonoBehaviour
{
    public State currentState;
    public GameObject firstState;

    public void OnStart() {
        currentState = firstState.GetComponent<State>();
    }

    void Update() {
        if(currentState != null)
            currentState.OnUpdate();
    }

    public void EditState(GameObject stateHolder) {
        var state = stateHolder.GetComponent<State>();

        if (currentState != state) {
            currentState = state;
        }
    }
}