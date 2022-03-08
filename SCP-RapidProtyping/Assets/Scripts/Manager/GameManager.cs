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
    public CameraMovement cameraMovement;
    public ActionStateMachine stateMachine;
    public Parasite parasite;
    public Values values;

    private void Start() {
        lookAround.Invoke("EnableCam", 2f);
        StartGame();
    }

    public void StartGame() {
        GetComponent<EndGame>().Restart();

        stateMachine.Invoke("OnStart", 2f);
        agentManager.OnStart();
        cameraMovement.EnableCam();
        parasite.Restart();
        values.Restart();
    }

    public void EndGame() {
        cameraMovement.active = false;
        stateMachine.currentState = null;
        GetComponent<EndGame>().StartSequence();
    }
}