using UnityEngine;
using System.Collections;

public interface IWeaponOutfit {

	int damageOutput(DamageType type);

	int weaponHealth();

	bool throwable();

	void onUnequip();

	void onEquip();

	GameObject getEntity();
}

public enum DamageType {
	MELEE,
	RANGED
};
