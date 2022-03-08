using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMissile : MonoBehaviour, IState
{
    public GameObject Missile;
    public GameObject Blinker;
    public GameObject BackPanel;
    public GameObject three;
    public GameObject two;
    public GameObject one;
    public GameObject Target;

    public new GameObject light;
    
    private AgentManager agent;

    private bool CanInvoke = true;

    private void Start() {
        agent = GameManager.instance.agentManager;
    }

    public void OnEnter() {
        Target.SetActive(true);
    }

    public void OnUpdate() {
        if (!CanInvoke)
            return;

        if (Input.GetButtonDown("Fire1")) {
            var tmp = GetComponentInParent<ClickScreen>().GetPos();

            if(tmp.collider.CompareTag("Ground"))
                StartCoroutine(SpawnMissile(tmp.point));
        }
    }

    public void OnExit() {
        Target.SetActive(false);
    }

    private IEnumerator SpawnMissile(Vector3 tmp) {
        Instantiate(Blinker, tmp, Quaternion.identity);

        CanInvoke = false;

        Target.SetActive(false);

        light.SetActive(true);

        foreach(GameObject dude in agent.Crowd) {
            dude.GetComponent<Agent>().agent.speed = 1.5f;
        }

        BackPanel.SetActive(true);
        three.SetActive(true);
        yield return new WaitForSeconds(1f);
        three.SetActive(false);

        two.SetActive(true);
        yield return new WaitForSeconds(1f);
        two.SetActive(false); 
        
        one.SetActive(true);
        yield return new WaitForSeconds(1f);
        one.SetActive(false);
        BackPanel.SetActive(false);

        Instantiate(Missile, tmp + new Vector3(0, 50, 0), Quaternion.identity);

        yield return new WaitForSeconds(10f);

        if (!GameManager.instance.parasite.Caught) {
            Target.SetActive(true);
            CanInvoke = true;
        }
    }
}