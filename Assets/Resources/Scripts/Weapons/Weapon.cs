using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Weapon : MonoBehaviour {
	private IWeaponOutfit outfit;
	private List<IWeaponOutfit> weaponInventory;

	// Use this for initialization
	void Start () {
		outfit = null;
		weaponInventory = new List<IWeaponOutfit>();
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
					if(outfit != null){
						unequipItem();
					}
					hit.collider.enabled = false;
					Rigidbody itembody = hit.transform.gameObject.GetComponent<Rigidbody>();
					itembody.isKinematic = true;
					equipItem(hit.transform.gameObject.GetComponent<Scrap>());
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

	}

	public bool itemEquipped()
	{
		return outfit != null;
	}
}
