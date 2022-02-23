using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Parasite : MonoBehaviour
{
    public Color CurrentHostMaterial;
    public Color DeadHostMaterial;

    private GameObject currentHost;
    private GameObject previousHost;
    private AgentManager AgentManager;

    public float timeToSwitch;
    private float timeSinceSwitch;
    public float timeToDie;
    public float range;

    private void Start() {
        AgentManager = GameManager.instance.agentManager;
    }

    void Update() {
        if (currentHost == null) {
            currentHost = AgentManager.Crowd[Random.Range(0, AgentManager.Crowd.Count - 1)];
            ChangeMaterial(currentHost, CurrentHostMaterial);
        }

        if (timeSinceSwitch > timeToSwitch) 
            GetNewHost();

        timeSinceSwitch += Time.deltaTime;
    }

    private void GetNewHost() {
        var agent = AgentManager.GetCloseEnemy(currentHost, range);

        if(agent == null) 
            return;

        previousHost = currentHost;
        StartCoroutine(KillDude(previousHost));

        currentHost = agent;
        ChangeMaterial(currentHost, CurrentHostMaterial);

        timeSinceSwitch = 0;
    }

    private void ChangeMaterial(GameObject host, Color material) {
         host.GetComponent<Renderer>().material.color = material;
    }

    private IEnumerator KillDude(GameObject host) {
        yield return new WaitForSeconds(timeToDie);

        host.GetComponent<NavMeshAgent>().SetDestination(host.transform.position);
        ChangeMaterial(host, DeadHostMaterial);
        AgentManager.KillDude(host);
    }
}
