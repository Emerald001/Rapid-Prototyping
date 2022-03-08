using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InvestigatorControl : MonoBehaviour, IState {
    public GameObject Pointer;
    
    private AgentManager AgentManager;
    private GameObject CurrentPointer;

    private float previousSpeed;
    private float timer;
    private float timerMax = 3;

    private void Start() {
        AgentManager = GameManager.instance.agentManager;
    }

    public void OnEnter() {

    }

    public void OnUpdate() {
        SlowDown();

        if (!Input.GetKeyDown(KeyCode.Mouse0))
            return;

        var tmp = GetComponentInParent<ClickScreen>().GetPos();

        if (tmp.collider.CompareTag("Human")) {
            foreach (GameObject investigator in AgentManager.Investigators) {
                investigator.GetComponent<Investigator>().DudeToCatch = tmp.collider.gameObject;

                if(CurrentPointer != null)
                    Destroy(CurrentPointer);

                CurrentPointer = Instantiate(Pointer, tmp.collider.transform);
            }
        }
        else {
            foreach (GameObject investigator in AgentManager.Investigators) {
                if (tmp.point != Vector3.zero) {
                    if (CurrentPointer != null) {
                        Destroy(CurrentPointer);
                    }
                    
                    investigator.GetComponent<Investigator>().DudeToCatch = null;
                    investigator.GetComponent<Investigator>().targetPostion = tmp.point;
                }
            }
        }
    }

    public void OnExit() {
        if (CurrentPointer != null) {
            Destroy(CurrentPointer);
        }
    }

    public void SlowDown() {
        if (Input.GetKeyDown(KeyCode.Mouse1) && timer < timerMax) {
            previousSpeed = AgentManager.Crowd[0].GetComponent<Agent>().agent.speed;

            foreach (GameObject dude in AgentManager.Crowd) {
                dude.GetComponent<Agent>().agent.speed = .1f;
            }
            foreach (GameObject dude in AgentManager.Investigators) {
                dude.GetComponent<Agent>().agent.speed = .1f;
            }
        }

        if (Input.GetKey(KeyCode.Mouse1) && timer < timerMax)
            timer += Time.deltaTime;
        else if (timer > 0)
            timer -= Time.deltaTime;
        else
            timerMax = 3f;

        if (Input.GetKeyUp(KeyCode.Mouse1) || timer > 3) {
            foreach (GameObject dude in AgentManager.Crowd) {
                dude.GetComponent<Agent>().agent.speed = previousSpeed;
            }
            foreach (GameObject dude in AgentManager.Investigators) {
                dude.GetComponent<Agent>().agent.speed = 1.5f;
            }

            timerMax = 0f;
        }
    }
}
