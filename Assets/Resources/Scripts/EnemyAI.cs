using UnityEngine;
using System.Collections;

public class EnemyAI {
	Vector3 waypoint;
	Transform target;
	NavMeshAgent agent;
	float distance;
	//how far away the enemy can see the player
	float detectionrange = 50f;
	//the range from which random waypoints can be selected
	float range = 10f;

	public EnemyAI(NavMeshAgent agent) : this(50f, agent) {}
	public EnemyAI(float detectionrange, NavMeshAgent agent)  {
		this.detectionrange = detectionrange;
		//if this becomes multiplayer, target will become a Transform[] and we can call FindGameObjectsWithTag("Player"), and get the transforms from the ones in that list
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		this.agent = agent;
	}

	/// <summary>
	/// Update function.
	/// should be called in the Update function
	/// </summary>
	/// <param name="transform">The calling class's transform object</param>
	public void Update(Transform transform) {
		//move
		agent.destination = waypoint;
		
		//have we reached the waypoint?
		if(Vector3.Distance(transform.position, waypoint) < 3f) {
			//go somewhere else
			Wander(transform);
		}
		if (target != null) {
			//distance to player
			distance = Vector3.Distance(target.position, transform.position);
			//alternatively, have we found a player?
			if (distance < detectionrange) {
				agent.destination = target.position;
			}
		}
	}
	//if there is no player found, the enemy will wander the area
	private void Wander(Transform transform) {
		//set a new random point to go to
		waypoint = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 1,
		                       Random.Range(transform.position.z - range, transform.position.z + range)
		                      );
		waypoint.y = 0.5f;
		transform.LookAt(waypoint);
	}
}