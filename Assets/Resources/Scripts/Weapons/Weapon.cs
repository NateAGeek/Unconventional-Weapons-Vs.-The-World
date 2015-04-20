using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Weapon : MonoBehaviour {
	private IWeaponOutfit outfit;
	private List<IWeaponOutfit> weaponInventory;
	private GameObject melee;

	// Use this for initialization
	void Start () {
		outfit = null;
		weaponInventory = new List<IWeaponOutfit>();
		/*
		melee = Instantiate(Resources.Load ("Prefabs/MeleeWeapon")) as GameObject;
		melee.transform.parent = transform;

		GameObject WoodPlankObject = Instantiate(Resources.Load ("Prefabs/WoodPlank")) as GameObject;
		WoodPlankObject.transform.parent = melee.transform;

		GameObject NailObject = Instantiate(Resources.Load ("Prefabs/MetalNail")) as GameObject;
		NailObject.transform.parent = melee.transform;


		MeleeWeapon melee_comp = melee.GetComponent<MeleeWeapon>();
		WoodPlank WoodPlankComp = WoodPlankObject.GetComponent<WoodPlank> ();
		MetalNail NailComp = WoodPlankObject.GetComponent<MetalNail> ();

		melee_comp.buildWeapon (WoodPlankComp, NailComp);
		*/

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){ //melee
			Debug.Log("Firin' mah lazer");
		}
		if(Input.GetButtonDown("Interact")){
			RaycastHit hit;
			Ray ray = transform.parent.gameObject.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));

			if(Physics.Raycast(ray, out hit)){
				if(hit.transform.gameObject.tag == "Interactable"){

				}
			}
		}
	}

	public void equipItem(IWeaponOutfit o)
	{
		outfit = o;
		GameObject entity = o.getEntity();
		entity.transform.rotation = transform.rotation;
		entity.transform.position = transform.position;
		entity.transform.SetParent(transform, true);
		o.onEquip();
	}

	public void unequipItem()
	{
		weaponInventory.Add(outfit);
		outfit.onUnequip();
	}

	public void dropItem()
	{
		//If just want to drop
		GameObject entity  = outfit.getEntity();
		Rigidbody itembody = entity.GetComponent<Rigidbody>();
		Collider collider  = entity.GetComponent<Collider>();
		
		collider.enabled        = true;
		itembody.isKinematic    = false;
		entity.transform.parent = null;
	}

	public bool itemEquipped()
	{
		return outfit != null;
	}
}
