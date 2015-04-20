using UnityEngine;
using System.Collections;

public abstract class DamageManager : HealthManager {

	public int maxDamage;

	//for some variety ;-)
	private int CalculateDamage() {
		return Random.Range (maxDamage - 5, maxDamage);
	}

	/// <summary>
	/// Deal damage to an entity with health
	/// </summary>
	/// <param name="other">the entity being damaged</param>
	public void DealDamage(HealthManager other) {
		other.ReceiveDamage (CalculateDamage ());
	}
}
