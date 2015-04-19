using UnityEngine;
using System.Collections;

public abstract class HealthManager : MonoBehaviour {
	public int maxHealth;
	protected int currentHealth;
	public bool isAlive = true;

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
		}
	}

	protected void CheckLiving() {
		if (!this.isAlive) {
			this.OnDead();
		}
	}

	/// <summary>
	/// called when isAlive = false, preferably in the Update method
	/// handles death of an entity
	/// </summary>
	protected abstract void OnDead();
}
