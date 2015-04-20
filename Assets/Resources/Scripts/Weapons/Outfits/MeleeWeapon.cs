using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeWeapon : HealthManager, IWeaponOutfit {
	private GameObject entity;
	private Dictionary<string, bool> WeaponComponets = new Dictionary<string, bool>(){
		{"Base"      , true},
		{"CrapInside", true},
	};
	private Dictionary<string, ScrapPiece> WeaponComponents = new Dictionary<string, ScrapPiece>();

	//constructors
	public MeleeWeapon() : this(15, 100) {}

	public MeleeWeapon(int durability) : this(15, durability) {}

	//the healthmanager lets us assign damage and durability (as an analogue to health)
	public MeleeWeapon(int damage, int durability) {
		this.maxDamage = damage;
		this.maxHealth = durability;
		this.currentHealth = this.maxHealth;
	}
	//

	public void buildWeapon(ScrapPiece base_model, ScrapPiece crap_inside){
		string baseWeaponName = base_model.name();
		string crapInsideWeaponName = crap_inside.name();
		WeaponComponents.Add(base_model.name(), base_model);
		WeaponComponents.Add(crap_inside.name(), crap_inside);

		WeaponComponents [baseWeaponName].onAttach();
		WeaponComponents [crapInsideWeaponName].onAttach();

	}

	public int damageOutput(DamageType type)
	{
		return 0;
	}

	public int weaponHealth()
	{
		return this.currentHealth;
	}

	public bool throwable()
	{
		return false;
	}

	public Dictionary<string, bool> getRecipe() {
		return WeaponComponets;
	}

	public void onUnequip()
	{

	}

	public void onEquip()
	{
		
	}

	public GameObject getEntity()
	{
		return entity;
	}

	protected override void OnDead() {

	}
}
