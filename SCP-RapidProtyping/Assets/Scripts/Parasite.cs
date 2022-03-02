using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Parasite : MonoBehaviour
{
    public Color CurrentHostMaterial;
    public Color DeadHostMaterial;

    public GameObject currentHost;
    private GameObject previousHost;
    private AgentManager AgentManager;

    public float timeToSwitch;
    private float timeSinceSwitch;
    public float timeToDie;
    public float range;

    public bool Caught;

    private void Start() {
        AgentManager = GameManager.instance.agentManager;
    }

    private void Update() {
        if (Caught)
            return;

        if (currentHost == null) {
            currentHost = AgentManager.Crowd[Random.Range(0, AgentManager.Crowd.Count - 1)];
            ChangeMaterial(currentHost, CurrentHostMaterial);
        }

        if (timeSinceSwitch > timeToSwitch) 
            GetNewHost();

        timeSinceSwitch += Time.deltaTime;
    }

    private void GetNewHost() {
        var dudesInRange = AgentManager.GetCloseEnemies(currentHost, range);
        GameObject tmp = null;

        if (dudesInRange.Length > 0) {
            tmp = dudesInRange[Random.Range(0, dudesInRange.Length)].gameObject;
        }

        if (!AgentManager.Crowd.Contains(tmp) || tmp == null || tmp == currentHost || !tmp.CompareTag("Human")) 
            return;

        previousHost = currentHost;
        StartCoroutine(KillDude(previousHost));

        currentHost = tmp;
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

    public void CaughtOrKilled() {
        Caught = true;
    }
}