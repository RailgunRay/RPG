using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIEnemies : MonoBehaviour {

    NavMeshAgent pathfinder;
    Transform target;
	
	void Start () {

        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, 0);
        pathfinder.SetDestination(targetPosition);
	}
}
