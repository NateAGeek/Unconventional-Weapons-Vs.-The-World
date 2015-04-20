using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileWeapon : IWeaponOutfit {
	private GameObject entity;
	private Dictionary<string, bool> WeaponComponets = new Dictionary<string, bool>(){
		{"Stock"  , true},
		{"Barrel" , true},
		{"Mag"    , true},
		{"Trigger", true},
	};
	private int health = 0;

	

	//Properties methods
	public bool throwable(){
		return false;
	}
	
	//Methods
	public int damageOutput(DamageType type){
		return 0;
	}

	public int weaponHealth(){
		return health;
	}

	public Dictionary<string, bool> getRecipe(){
		return WeaponComponets;
	}

	//Equip methods
	public void onUnequip(){

	}

	public void onEquip(){

	}
	
	public GameObject getEntity(){
		return entity;
	}
}
