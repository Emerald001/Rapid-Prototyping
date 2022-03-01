using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    public GameObject agent;
    public GameObject investigator;

    public int cSpawnAmount;
    public int aSpawnAmount;
    public int spawnRadius;

    public List<GameObject> Investigators = new List<GameObject>();
    public List<GameObject> Crowd = new List<GameObject>();
    public List<GameObject> DeadCrowd = new List<GameObject>();

    void Start() {
        for (int i = 0; i < cSpawnAmount; i++) {
            var pos = RandomNavmeshLocation(this.transform.position, spawnRadius);
            while(pos == Vector3.zero) {
                pos = RandomNavmeshLocation(this.transform.position, spawnRadius);
            }
            var tmp = Instantiate(agent, pos, Quaternion.identity);
            Crowd.Add(tmp);
            tmp.transform.parent = this.transform;
            tmp.GetComponent<Agent>().lookAroundRange = Random.Range(1, 10);
            tmp.GetComponent<Agent>().OnStart();
        }

        for (int i = 0; i < aSpawnAmount; i++) {
            var pos = RandomNavmeshLocation(this.transform.position, spawnRadius);
            while (pos == Vector3.zero) {
                pos = RandomNavmeshLocation(this.transform.position, spawnRadius);
            }
            var tmp = Instantiate(investigator, pos, Quaternion.identity);
            Investigators.Add(tmp);
            tmp.transform.parent = this.transform;
            tmp.GetComponent<Agent>().OnStart();
        }
    }

    private void Update() {
        foreach (GameObject dude in Crowd) {
            dude.GetComponent<Agent>().OnUpdate();
        }

        foreach (GameObject dude in DeadCrowd) {
            dude.GetComponent<Agent>().OnKilledUpdate();
        }
    }

    public Vector3 RandomNavmeshLocation(Vector3 pos, float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += pos;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public Collider[] GetCloseEnemies(GameObject currentObject, float range) {
        Collider[] hitColliders = Physics.OverlapSphere(currentObject.transform.position, range);

        return hitColliders;
    }

    public void KillDude(GameObject dude) {
        Crowd.Remove(dude);
        GameManager.instance.values.cDeadAmount++;
        DeadCrowd.Add(dude);
    }
}