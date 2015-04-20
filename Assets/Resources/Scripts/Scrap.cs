using UnityEngine;
using System.Collections;

public class Scrap : MonoBehaviour, IWeaponOutfit {
	public int meleeDmg;
	public int rangeDmg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int damageOutput(DamageType type)
	{
		switch(type){
			case DamageType.MELEE:
				return meleeDmg;
			case DamageType.RANGED:
				return rangeDmg;
			default:
				return 0;
		}
	}

	public int weaponHealth()
	{
		return 0;
	}

	public bool throwable()
	{
		return true;
	}

	public void onUnequip()
	{
		//gameObject.SetActive(true);
	}

	public void onEquip()
	{
		//gameObject.SetActive(true);
	}

	public GameObject getEntity()
	{
		return gameObject;
	}
}
