using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public IWeaponOutfit outfit;

	// Use this for initialization
	void Start () {
		outfit = null;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Debug.Log("Firin' mah lazer");
		}
		if(Input.GetButtonDown("Interact")){
			RaycastHit hit;
			Ray ray = transform.parent.gameObject.GetComponentInChildren<Camera>().ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));

			if(Physics.Raycast(ray, out hit)){
				if(hit.transform.gameObject.tag == "Interactable"){
					outfit = hit.transform.gameObject.GetComponent<Scrap>();
					Rigidbody itembody = hit.transform.gameObject.GetComponent<Rigidbody>();
					itembody.isKinematic = true;
					hit.transform.rotation = transform.rotation;
					hit.transform.position = transform.position;
					hit.transform.SetParent(transform, true);
				}
			}
		}
	}

	public void equipItem(IWeaponOutfit o)
	{
		outfit = o;
	}

	public bool itemEquipped()
	{
		return outfit != null;
	}
}
