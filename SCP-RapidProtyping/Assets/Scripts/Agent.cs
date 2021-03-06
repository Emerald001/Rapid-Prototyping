using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public AgentManager AgentManager;

    public float lookAroundRange;
    public NavMeshAgent agent;

    public float TimeToDespawn;
    private float TimeSinceDeath;
    private float BreakoutTimer;

    public bool stopped;

    public void OnStart() {
        AgentManager = GameManager.instance.agentManager;

        agent = this.GetComponent<NavMeshAgent>();
        if(lookAroundRange != 0) {
            var pos = AgentManager.RandomNavmeshLocation(this.transform.position, lookAroundRange);
            while (pos == Vector3.zero) {
                pos = AgentManager.RandomNavmeshLocation(this.transform.position, lookAroundRange);
            }
            agent.SetDestination(pos);
        }
    }

    public void OnUpdate() {
        if (stopped){
            return;
        }

        if (agent.remainingDistance < .1f) {
            var pos = AgentManager.RandomNavmeshLocation(this.transform.position, lookAroundRange);
            while (pos == Vector3.zero) {
                pos = AgentManager.RandomNavmeshLocation(this.transform.position, lookAroundRange);
            }
            agent.SetDestination(pos);
            BreakoutTimer = 0;
        }

        BreakoutTimer += Time.deltaTime;

        if(BreakoutTimer > 5) {
            var pos = AgentManager.RandomNavmeshLocation(this.transform.position, lookAroundRange);
            while (pos == Vector3.zero) {
                pos = AgentManager.RandomNavmeshLocation(this.transform.position, lookAroundRange);
            }
            agent.SetDestination(pos);
            BreakoutTimer = 0;
        }
    }

    public void OnKilledUpdate() {
        var list = AgentManager.GetCloseEnemies(this.gameObject, 2f);

        if (list.Length < 1)
            return;

        foreach(Collider dude in list) {
            if(dude.gameObject != this.gameObject && AgentManager.Crowd.Contains(dude.gameObject)) {
                var tmp = dude.gameObject.GetComponent<Agent>();
                var offset = new Vector3(Random.Range(-.3f, .3f), 0, Random.Range(-.3f, .3f));
                var dir = -(this.transform.position - tmp.gameObject.transform.position).normalized + offset;
                tmp.RunAway(dir);
            }
        }

        TimeSinceDeath += Time.deltaTime;

        if (TimeSinceDeath >= TimeToDespawn) {
            AgentManager.DeadCrowd.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void RunAway(Vector3 runDir) {
        Vector3 newGoal = this.transform.position + runDir * 10;
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(newGoal, path);

        if(path.status != NavMeshPathStatus.PathInvalid) {
            agent.SetDestination(path.corners[path.corners.Length - 1]);
        }
    }
}