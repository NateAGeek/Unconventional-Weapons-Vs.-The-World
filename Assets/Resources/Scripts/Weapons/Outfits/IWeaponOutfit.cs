using UnityEngine;
using System.Collections;

public interface IWeaponOutfit {
	
	//Properties methods
	bool throwable();

	//Methods
	int damageOutput(DamageType type);
	int weaponHealth();

	//Equip methods
	void onUnequip();
	void onEquip();

	GameObject getEntity();
}

public enum DamageType {
	MELEE,
	RANGED
};
