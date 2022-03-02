using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMissile : MonoBehaviour, State
{
    public GameObject Missile;
    public GameObject Blinker;
    public GameObject backPanel;
    public GameObject three;
    public GameObject two;
    public GameObject one;

    public GameObject light;
    
    private AgentManager agent;

    private bool CanInvoke = true;

    private void Start() {
        agent = GameManager.instance.agentManager;
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

    private IEnumerator SpawnMissile(Vector3 tmp) {
        Instantiate(Blinker, tmp, Quaternion.identity);

        CanInvoke = false;

        light.SetActive(true);

        foreach(GameObject dude in agent.Crowd) {
            dude.GetComponent<Agent>().agent.speed = 1.5f;
        }

        backPanel.SetActive(true);
        three.SetActive(true);
        yield return new WaitForSeconds(1f);
        three.SetActive(false);

        two.SetActive(true);
        yield return new WaitForSeconds(1f);
        two.SetActive(false); 
        
        one.SetActive(true);
        yield return new WaitForSeconds(1f);
        one.SetActive(false);
        backPanel.SetActive(false);

        Instantiate(Missile, tmp + new Vector3(0, 50, 0), Quaternion.identity);

        yield return new WaitForSeconds(10f);
        CanInvoke = true;
    }
}