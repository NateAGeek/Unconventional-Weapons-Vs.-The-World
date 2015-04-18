using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	Vector3 waypoint;
	Transform target;
	NavMeshAgent agent;
	float distance;
	float range = 10f;
	//float speed = 20f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		Wander();
	}
	
	// Update is called once per frame
	void Update () {
		//move
		agent.destination = waypoint;
		//transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
		
		//have we reached the waypoint?
		if(Vector3.Distance(transform.position, waypoint) < 3f) {
			//go somewhere else
			Wander();
			//StartCoroutine("Pause");
		}
		if (target != null) {
			//distance to player
			distance = Vector3.Distance(target.position, transform.position);
			//alternatively, have we found a player?
			if (distance < range) {
				agent.destination = target.position;
			}
		}
	}

	/*IEnumerator Pause() {
		Wander();
		yield return new WaitForSeconds(2);
	}*/

	void Wander() {
		waypoint = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 1,
		                       Random.Range(transform.position.z - range, transform.position.z + range)
		                      );
		waypoint.y = 0.5f;
		transform.LookAt(waypoint);
		//log the waypoint and its distance
		Debug.Log(waypoint + " and " + (transform.position - waypoint).magnitude);
	}
}