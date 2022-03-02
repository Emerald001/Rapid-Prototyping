using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    public AgentManager agentManager;
    public LookAround lookAround;
    public ActionStateMachine stateMachine;
    public Parasite parasite;
    public Values values;
    public GameObject GotIt;

    private void Start() {
        lookAround.Invoke("EnableCam", 2f);
        stateMachine.Invoke("OnStart", 2f);
    }
}