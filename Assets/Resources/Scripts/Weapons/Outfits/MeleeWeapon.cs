using UnityEngine;
using System.Collections;

public class MeleeWeapon : IWeaponOutfit {
	private Scrap weaponBase;
	private Scrap accessory;
	private GameObject entity;

	public MeleeWeapon()
	{
		weaponBase = null;
		accessory = null;
	}

	public int damageOutput(DamageType type)
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
}
