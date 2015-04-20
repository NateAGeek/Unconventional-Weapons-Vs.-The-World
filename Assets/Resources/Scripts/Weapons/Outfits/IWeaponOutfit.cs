using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IWeaponOutfit {
	
	//Properties methods
	bool throwable();

	//Methods
	int damageOutput(DamageType type);
	int weaponHealth();

	//Equip methods
	void onUnequip();
	void onEquip();

	Dictionary<string, bool> getRecipe();

	GameObject getEntity();
}

public enum DamageType {
	MELEE,
	RANGED
};
