using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public float lookAroundRange;
    private NavMeshAgent agent;

    public void OnStart() {
        agent = this.GetComponent<NavMeshAgent>();
        var pos = RandomNavmeshLocation(lookAroundRange);
        while (pos == Vector3.zero) {
            pos = RandomNavmeshLocation(lookAroundRange);
        }
        agent.SetDestination(pos);
    }

    public void OnUpdate() {
        if (agent.remainingDistance < .1f) {
            var pos = RandomNavmeshLocation(lookAroundRange);
            while (pos == Vector3.zero) {
                pos = RandomNavmeshLocation(lookAroundRange);
            }
            agent.SetDestination(pos);
        }
    }

    public void RunAway() {

    }

    public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
