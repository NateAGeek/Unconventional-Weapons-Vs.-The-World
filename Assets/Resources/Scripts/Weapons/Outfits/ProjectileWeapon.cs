using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileWeapon : IWeaponOutfit {
	private GameObject entity;
	private Dictionary<string, Vector3> WeaponComponets = new Dictionary<string, Vector3>(){
		{"Stock"  , new Vector3(0.0f, 0.0f, 0.0f)},
		{"Barrel" , new Vector3(0.0f, 0.0f, 0.0f)},
		{"Mag"    , new Vector3(0.0f, 0.0f, 0.0f)},
		{"Trigger", new Vector3(0.0f, 0.0f, 0.0f)},
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
	
	//Equip methods
	public void onUnequip(){

	}

	public void onEquip(){

	}
	
	public GameObject getEntity(){
		return entity;
	}
}
