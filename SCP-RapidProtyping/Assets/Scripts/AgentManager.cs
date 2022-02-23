using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    public GameObject agent;

    public int spawnAmount;
    public int spawnRadius;

    public List<GameObject> Crowd = new List<GameObject>();
    public List<GameObject> DeadCrowd = new List<GameObject>();

    void Start() {
        for (int i = 0; i < spawnAmount; i++) {
            var pos = RandomNavmeshLocation(spawnRadius);
            while(pos == Vector3.zero) {
                pos = RandomNavmeshLocation(spawnRadius);
            }
            var tmp = Instantiate(agent, pos, Quaternion.identity);
            Crowd.Add(tmp);
            tmp.transform.parent = this.transform;
            tmp.GetComponent<Agent>().lookAroundRange = Random.Range(1, 10);
            tmp.GetComponent<Agent>().OnStart();
        }
    }

    private void Update() {
        foreach(GameObject dude in Crowd) {
            dude.GetComponent<Agent>().OnUpdate();
        }
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

    public GameObject GetCloseEnemy(GameObject currentObject, float range) {
        GameObject tmp = null;
        Collider[] hitColliders = Physics.OverlapSphere(currentObject.transform.position, range);

        if (hitColliders.Length > 0) 
            tmp = hitColliders[Random.Range(0, hitColliders.Length)].gameObject;

        if (tmp != null) {
            if (!DeadCrowd.Contains(tmp) && tmp != currentObject) {
                return tmp;
            }
        }

        return null;
    }

    public void KillDude(GameObject dude) {
        Crowd.Remove(dude);
        DeadCrowd.Add(dude);
    }
}
