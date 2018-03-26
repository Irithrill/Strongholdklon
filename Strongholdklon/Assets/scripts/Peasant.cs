using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Peasant : MonoBehaviour {

    public int status = 0;
    public int job = 0;

    bool moving = false;

    void Start () {
        WanderAround();
    }
	
	void Update () {
        NavMeshAgent mNavMeshAgent = GetComponent<NavMeshAgent>();

        if(!mNavMeshAgent.pathPending && moving) {
            if(mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance) {
                if(!mNavMeshAgent.hasPath || mNavMeshAgent.velocity.sqrMagnitude == 0f) {
                   // Debug.Log("Done walking");
                    moving = false;
                    WanderAround();
                }
            }
        }
    }

    void WanderAround() {
        if(status != 0) {
            return;
        }

        float x = Random.Range(-30, 30);
        float z = Random.Range(-30, 30);
        goTo(new Vector3(x,0,z));
    }

    public void goTo(Vector3 pos) {
        moving = true;

        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(pos);
    }
}
