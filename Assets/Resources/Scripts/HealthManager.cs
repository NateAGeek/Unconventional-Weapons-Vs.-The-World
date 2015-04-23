using UnityEngine;
using System.Collections;

public abstract class HealthManager : MonoBehaviour {

	//health
	public int maxHealth;
	public int currentHealth;
	public bool isAlive = true;

	//damage
	public int maxDamage;

	/// <summary>
	/// when one entity damages another, call this method to apply the damage.
	/// for example, if a gnome hits the player, the gnome would call:
	/// player.ReceiveDamage(damageValue);
	/// </summary>
	/// <param name="damage">Damage dealt</param>
	public void ReceiveDamage(int damage) {
		this.currentHealth -= damage;

		if (this.currentHealth <= 0) {
			this.isAlive = false;
			this.OnDead();
		}
	}

	/// <summary>
	/// Deal damage to an entity with health
	/// </summary>
	/// <param name="other">the entity being damaged</param>
	public void DealDamage(HealthManager other) {
		other.ReceiveDamage (CalculateDamage ());
	}

	/// <summary>
	/// called when isAlive = false, preferably in the Update method
	/// handles death of an entity
	/// </summary>
	protected abstract void OnDead();

	//for some variety ;-)
	//this can either be changed or overridden in subclasses
	protected int CalculateDamage() {
		return maxDamage;
	}
}