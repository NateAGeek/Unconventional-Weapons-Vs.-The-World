using UnityEngine;
using System.Collections;

public class Gnome : HealthManager {

	private NavMeshAgent agent;
	private EnemyAI      ai;
	private Rigidbody    rigidbody;
	private bool         knockedback;
	private bool         isAttacking;
	private float        lastAttackTime;
	private float        attackCooldown = 1f;

	// Use this for initialization
	void Start () {
		//if the maxhealth isn't already set
		if (maxHealth == 0) {
			maxHealth = 100;
		}
		currentHealth = this.maxHealth;
		//if the maxdamage isn't already set
		if (maxDamage == 0) {
			maxDamage = 15;
		}
		agent = GetComponent<NavMeshAgent>();
		rigidbody = GetComponent<Rigidbody>();
		isAttacking = false;
		ai = new EnemyAI (this.agent);
	}
	
	// Update is called once per frame
	void Update () {
		//check to see if this entity is still living
		if (knockedback) {
			agent.Stop();
			Debug.Log("Knocked Back: "+rigidbody.velocity.magnitude);
			if(rigidbody.velocity.magnitude >= 5.0f){
				knockedback = false;
				rigidbody.velocity = Vector3.zero;
			}
			agent.Resume();
		}
		//refresh the attack cooldown
		if(Time.time >= lastAttackTime + attackCooldown) {
			isAttacking = false;
		}

		ai.Update (transform);
	}

	void OnCollisionStay(Collision hit){
		if (hit.gameObject.tag == "Player") {
			if(!isAttacking) {
				isAttacking = true;
				PlayerObjectScript player = hit.gameObject.GetComponent<PlayerObjectScript>();
				DealDamage(player);
				lastAttackTime = Time.time;
			}
		}
	}

	public void knockbackGnome(Transform hit_transform){
		if (!knockedback) {
			knockedback = true;
			agent.Stop ();
			rigidbody.AddForce (hit_transform.forward * 1000.0f, ForceMode.Force);
		}
	}

	protected override void OnDead() {
		//handle death
		Destroy(this.gameObject);
	}
}
