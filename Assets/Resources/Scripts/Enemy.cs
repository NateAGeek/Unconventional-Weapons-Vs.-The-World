using UnityEngine;
using System.Collections;

public class Enemy : HealthManager {

	private NavMeshAgent agent;
	private EnemyAI ai;

	// Use this for initialization
	void Start () {
		//if the maxhealth isn't already set
		if (this.maxHealth == 0) {
			this.maxHealth = 100;
		}
		this.currentHealth = this.maxHealth;
		//if the maxdamage isn't already set
		if (this.maxDamage == 0) {
			this.maxDamage = 15;
		}
		this.agent = GetComponent<NavMeshAgent> ();
		this.ai = new EnemyAI (this.agent);
	}
	
	// Update is called once per frame
	void Update () {
		//check to see if this entity is still living
		this.ai.Update (this.transform);
	}

	void OnTriggerStay(Collider other) {
		//if the object triggering the collider is a player...
		if (other.transform.tag == "Player") {
			//...get the player as a script...
			DummyObjectScript player = other.gameObject.GetComponent<DummyObjectScript>();
			//...and damage it
			this.DealDamage(player);
		}
	}

	protected override void OnDead() {
		//handle death
		Destroy(this.gameObject);
	}
}
