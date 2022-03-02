using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Investigator : Agent 
{
    public Vector3 targetPostion;
    public GameObject DudeToCatch;

    void Update() {
        if(DudeToCatch != null) {
            if (Vector3.Distance(transform.position, DudeToCatch.transform.position) > .5f) {
                targetPostion = DudeToCatch.transform.position;
            }
            else {
                DudeToCatch.GetComponent<Agent>().agent.SetDestination(DudeToCatch.transform.position);
                DudeToCatch.GetComponent<Agent>().stopped = true;

                var list = AgentManager.GetCloseEnemies(this.gameObject, 5f);

                if (list.Length < 1)
                    return;

                foreach (Collider dude in list) {
                    if (dude.gameObject != this.gameObject && AgentManager.Crowd.Contains(dude.gameObject)) {
                        var tmp = dude.gameObject.GetComponent<Agent>();
                        var offset = new Vector3(Random.Range(-.3f, .3f), 0, Random.Range(-.3f, .3f));
                        var dir = -(this.transform.position - tmp.gameObject.transform.position).normalized + offset;
                        tmp.RunAway(dir);
                    }
                }

                if (GameManager.instance.parasite.Caught) 
                    return;

                if (GameManager.instance.parasite.currentHost == DudeToCatch) {
                    GameManager.instance.parasite.CaughtOrKilled();
                }
            }
        }

        if(targetPostion != Vector3.zero) {
            if(Vector3.Distance(transform.position, targetPostion) < .2f) {
                targetPostion = Vector3.zero;
                return;
            }
            agent.SetDestination(targetPostion);
        }
    }

    new public void RunAway(Vector3 runDir) {
        return;
    }
}