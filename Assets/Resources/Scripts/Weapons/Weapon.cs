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
	
	}

	public void equipItem(IWeaponOutfit o)
	{
		outfit = o;
	}
}
