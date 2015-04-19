using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	public float fov = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;

	private NavMeshAgent nav;
	private SphereCollider col;
	private GameObject player;
	private Vector3 previousSighting;

	void Awake() {
		this.nav = GetComponent<NavMeshAgent>();
		this.col = GetComponent<SphereCollider>();
		this.player = GameObject.FindGameObjectWithTag("Player");

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//when something is in the enemy's detection range...
	void OnTriggerStay(Collider other) {
		//if that something is a player...
		if (other.gameObject == this.player) {
			//default to false
			this.playerInSight = false;

			Vector3 direction = other.transform.position - this.transform.position;
			float angle = Vector3.Angle(direction, this.transform.forward);

			//if the angle between the enemy's forward direction and the player is less than half of the fov, the player could be in direct line of sight...
			if(angle < this.fov * 0.5f) {
				RaycastHit hit;

				//...but there could also be something in the way
				if(Physics.Raycast(this.transform.position, direction.normalized, out hit, this.col.radius)) {
					//so if the player is actually visible...
					this.playerInSight = true;
					//update global sighting if necessary
				}
			}
		}
	}

	//if the player leaves the detection range, they can't be detected (obviously)
	void OnTriggerExit(Collider other) {
		if (other.gameObject == this.player) {
			this.playerInSight = false;
		}
	}

	//is the player audible? if the path length is less than or equal to the detection range, then I say yes!
	float CalculatePathLength(Vector3 target) {
		//compute the path using the navmesh
		NavMeshPath path = new NavMeshPath();
		if (this.nav.enabled) {
			this.nav.CalculatePath(target, path);
		}

		//find the points on the path
		Vector3[] points = new Vector3[path.corners.Length + 2];
		points [0] = this.transform.position;
		points [points.Length - 1] = target;
		for (int i = 0; i < path.corners.Length; i++) {
			points[i + 1] = path.corners[i];
		}

		//compute the length of the path
		float pathlength = 0f;
		for (int i = 0; i < points.Length - 1; i++) {
			pathlength += Vector3.Distance(points[i], points[i + 1]);
		}
		return pathlength;
	}
}
