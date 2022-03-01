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
            agent.SetDestination(DudeToCatch.transform.position);
        }
        else if(targetPostion != Vector3.zero) {
            if(Vector3.Distance(transform.position, targetPostion) < 2f) {
                targetPostion = Vector3.zero;
                return;
            }
            agent.SetDestination(targetPostion);
        }
    }
}