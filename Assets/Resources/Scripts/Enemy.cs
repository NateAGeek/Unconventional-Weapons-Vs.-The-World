using UnityEngine;
using System.Collections;

public class Enemy : HealthManager {

	private NavMeshAgent agent;
	private EnemyAI ai;

	private CapsuleCollider damager;

	// Use this for initialization
	void Start () {
		this.maxHealth = 100;
		this.currentHealth = this.maxHealth;
		this.agent = GetComponent<NavMeshAgent> ();
		this.ai = new EnemyAI (this.agent);
		this.damager = GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		ai.Update (this.transform);
	}

	public override void OnDead() {
		//handle death
		Destroy (this.gameObject);
	}
}
