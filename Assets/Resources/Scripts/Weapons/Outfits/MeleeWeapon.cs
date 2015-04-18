using UnityEngine;
using System.Collections;

public class MeleeWeapon : IWeaponOutfit {
	private Scrap weaponBase;
	private Scrap accessory;

	public MeleeWeapon()
	{
		weaponBase = null;
		accessory = null;
	}

	public int damageOutput()
	{
		return 0;
	}

	public int weaponHealth()
	{
		return 0;
	}

	public bool throwable()
	{
		return false;
	}
}
